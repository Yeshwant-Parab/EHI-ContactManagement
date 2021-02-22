using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using EHI.UserManagement.Dto.Contact;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace EHI.UserManagement.Web.Controllers
{
    /// <summary>
    /// Contact MVC Controller for UI
    /// </summary>
    public class ContactController : Controller
    { 
        readonly string _baseurl;
        readonly IConfiguration _configuration;
        HttpClient _client = new HttpClient();

        public ContactController(IConfiguration iconfig)
        {
           //_baseurl = _configuration.Get.GetValue<string>("ApiUrl:DefaultUrl");
            _baseurl = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ApiUrl")["DefaultUrl"];
            _client.BaseAddress = new Uri(_baseurl);
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        // GET: ContactController
        public async Task<ActionResult> Index()
        {
            HttpResponseMessage res = await _client.GetAsync("api/contact");
            if (res.IsSuccessStatusCode)
            { 
                var resp = res.Content.ReadAsStringAsync().Result;
                var contacts = JsonConvert.DeserializeObject<List<ContactDetails>>(resp);
                return View(contacts);
            }
            return View("Error");
        }

        // GET: ContactController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            HttpResponseMessage res = await _client.GetAsync("api/contact/"+id);
            if (res.IsSuccessStatusCode)
            { 
                var resp = res.Content.ReadAsStringAsync().Result; 
                var contacts = JsonConvert.DeserializeObject<ContactDetails>(resp);
                return View(contacts);
            }
            return View("Error");
        }

        // GET: ContactController/Create
        public ActionResult Create()
        {
            var newContact = new ContactDetails();
            return View(newContact);
        }

        // POST: ContactController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm]ContactDetails contact)
        {
            try
            {
                HttpResponseMessage res = await _client.PostAsync<ContactDetails>("api/contact", contact, new JsonMediaTypeFormatter());

                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View("Error");
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: ContactController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            HttpResponseMessage res = await _client.GetAsync("api/contact/" + id);
            if (res.IsSuccessStatusCode)
            {
                var resp = res.Content.ReadAsStringAsync().Result;
                var contacts = JsonConvert.DeserializeObject<ContactDetails>(resp);
                return View(contacts);
            }
            return View("Error");
        }

        // POST: ContactController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, [FromForm] ContactDetails contact)
        {
            try
            {
                HttpResponseMessage res = await _client.PutAsync<ContactDetails>("api/contact", contact, new JsonMediaTypeFormatter());

                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View("Error");
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: ContactController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            HttpResponseMessage res = await _client.GetAsync("api/contact/" + id);
            if (res.IsSuccessStatusCode)
            {
                var resp = res.Content.ReadAsStringAsync().Result;
                var contacts = JsonConvert.DeserializeObject<ContactDetails>(resp);
                return View(contacts);
            }
            return View("Error");
        }

        // POST: ContactController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, [FromForm] ContactDetails contact)
        {
            try
            {
                HttpResponseMessage res = await _client.DeleteAsync("api/contact/" +id);

                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View("Error");
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
