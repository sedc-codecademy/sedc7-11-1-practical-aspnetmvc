using AutoMapper;
using DataAccess.Interfaces;
using Domain.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using WebModels.ViewModels;

namespace Services.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IRepository<Invoice> _invoiceRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IMapper _mapper;

        public InvoiceService(IRepository<Invoice> invoiceRepository,
            IRepository<Order> orderRepository,
            IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public IEnumerable<InvoiceViewModel> GetAll()
        {
            IEnumerable<Invoice> invoices = _invoiceRepository.GetAll();
            return _mapper.Map<IEnumerable<InvoiceViewModel>>(invoices);
        }

        public InvoiceViewModel GetById(int id)
        {
            Invoice invoice = _invoiceRepository.GetById(id);
            return _mapper.Map<InvoiceViewModel>(invoice);
        }

        public InvoiceViewModel GetByOrderId(int id)
        {
            Order order = _orderRepository.GetById(id);
            Invoice invoice = _invoiceRepository.GetById(order.Invoice.Id);
            return _mapper.Map<InvoiceViewModel>(invoice);
        }

        public int Insert(InvoiceViewModel model, int orderId)
        {
            Order order = _orderRepository.GetById(orderId);
            Invoice invoice = _mapper.Map<Invoice>(model);
            invoice.Order = order;
            return _invoiceRepository.Insert(invoice);
        }
    }
}
