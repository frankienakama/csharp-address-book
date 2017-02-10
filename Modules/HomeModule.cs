using Nancy;
using System.Collections.Generic;
using AddressBook.Objects;

namespace AddressBook
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };
      Get["/contacts"] = _ => {
        var allContacts = Contact.GetAll();
        return View["contacts.cshtml", allContacts];
      };
      Get["/contact/new"] = _ => {
        return View["add_contact.cshtml"];
      };
      Get["/contacts/clear"] = _ => {
        return View["contacts_cleared.cshtml"];
      };
      Post["/contacts"] = _ => {
        var newContact = new Contact(Request.Form["add-contact"]);
        var allContacts = Contact.GetAll();
        return View["contacts.cshtml", allContacts];
      };
      Get["/contacts/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var selectedContact = Contact.Find(parameters.id);
        var getCotact = selectedContact.GetInfo();
        model.Add("contact", selectedContact);
        model.Add("input", getCotact);
        return View["contact.cshtml", model];
      };
      // Post["/contact_info"] = _ => {
      //   Dictionary<string, object> model = new Dictionary<string, object>();
      //   Contact selectedContact = Contact.Find(Request.Form["category-id"]);
      //   List<ContactInfo> getCotact = selectedContact.GetInfo();
      //   string contactDescription = Request.Form["task-description"];
      //   ContactInfo newTask = new ContactInfo(contactDescription);
      //   getCotact.Add(newTask);
      //   model.Add("input", getCotact);
      //   model.Add("contact", selectedContact);
      //   return View["contact.cshtml", model];
      // };
    }
  }
}
