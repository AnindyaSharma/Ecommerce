using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceApp.Database;
using EcommerceApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        EcommerceDBContex db = new EcommerceDBContex();
        public IActionResult Create()
        {
            Customer customer = new Customer();
            customer.CustomerList = db.customers.ToList();
            return View(customer);
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                EcommerceDBContex db = new EcommerceDBContex();
                db.customers.Add(customer);

                bool isSaved = db.SaveChanges() > 0;

                if (isSaved)
                {
                    return RedirectToAction("List", "Customer", null);
                }
            }
            return View();
        }

        public IActionResult List()
        {
            //get all customers from ecommerceDBContex
            EcommerceDBContex db = new EcommerceDBContex();
            List<Customer> customers = db.customers.ToList();

            //show the customers in view
            return View(customers);
        }

        //Customer/Edit/Id
        public IActionResult Edit(int? id)
        {
            EcommerceDBContex db = new EcommerceDBContex();
            if (id != null && id > 0)
            {
                Customer existingCustomer = db.customers.Find(id);

                if (existingCustomer != null)
                {
                    return View(existingCustomer);
                }

            }

            return View();
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if (customer != null)
            {
                EcommerceDBContex ecommerceDBContex = new EcommerceDBContex();
                //Customer existingCustomer = ecommerceDBContex.customers.Find(customer.Id);
                //if(existingCustomer != null)
                //{
                //    existingCustomer.Name = customer.Name;
                //    existingCustomer.Phone = customer.Phone;
                //    existingCustomer.Address = customer.Address;

                //    ecommerceDBContex.SaveChanges();

                //}

                ecommerceDBContex.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                bool isUpdate = ecommerceDBContex.SaveChanges() > 0;

                if (isUpdate)
                {
                    return RedirectToAction("List");
                }

            }

            return View(customer);
        }
    }
}