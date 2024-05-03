using AutoMapper;
using System.Net.Mail;
using System.Net;
using Tecnofactory.Alimentos.BL.Interface;
using Tecnofactory.Alimentos.DAL.Entity;
using Tecnofactory.Alimentos.DAL.Repository.Interface;
using Tecnofactory.Alimentos.DTO;

namespace Tecnofactory.Alimentos.BL
{
    public class OrderCreationService : IOrderCreationService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICatalogueRepository _catalogueRepository;
        private readonly IMapper _mapper;
        public OrderCreationService(IOrderRepository orderRepository, ICatalogueRepository catalogueRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _catalogueRepository = catalogueRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddUserOrder(UserOrderDto userOrder)
        {
            Catalogue catalogue = _catalogueRepository.GetById(userOrder.CatalogueId);
            if (catalogue != null && catalogue.Quantity > 0 && catalogue.Quantity >= userOrder.Quantity)
            {
                Order order = _mapper.Map<Order>(userOrder);
                order.Price = catalogue.Price * userOrder.Quantity;
                Guid id = _orderRepository.Create(order);

                catalogue.Quantity -= userOrder.Quantity;
                _catalogueRepository.Update(catalogue);

                _ = await SendOrderEmail(userOrder.Email!, id);

                return true;
            }
            return false;
        }

        public List<UserOrderDto> GetAllOrders()
        {
            List<Order> orders = _orderRepository.Get();
            return _mapper.Map<List<UserOrderDto>>(orders);
        }

        private static async Task<bool> SendOrderEmail(string email, Guid idOrder)
        {
            var Mensaje = new MailMessage();
            Mensaje.To.Add(new MailAddress(email));
            Mensaje.From = new MailAddress("probadorcorreomartinez@outlook.com");
            Mensaje.Subject = string.Concat("Pedido de Alimentos ", idOrder.ToString());
            Mensaje.Body = string.Concat("¡Gracias por su compra! \nConfirmación de pedido de alimentos nro. ", idOrder.ToString());
            Mensaje.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credencial = new NetworkCredential
                {
                    UserName = "probadorcorreomartinez@outlook.com",
                    Password = "19735ProbadorLj*",
                };
                smtp.Credentials = credencial;
                smtp.Host = "smtp.office365.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                
                await smtp.SendMailAsync(Mensaje);
            }

            return true;
        }
    }
}
