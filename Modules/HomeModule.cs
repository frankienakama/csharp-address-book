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
        var allContacts = Contact.GetAll();
        return View["index.cshtml", allContacts];
      };
      Get["/contact/new"] = _ => {
        return View["new_contact_confirmation.cshtml"];
      };
      Get["/contact/add"] = _ => {
        return View["add_a_new_contact.cshtml"];
      };
      Post["/contact/add"] = _ => {
        var newContact = new Contact(Request.Form["new-contact"]);
        var allContacts = Contact.GetAll();
        return View["add_a_new_contact.cshtml", allContacts];
      };
      Get["/contact/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var selectedContact = ContactInfo.Find(parameters.id);
        var selectedContactInfo = selectedContact.GetContactInfo();
        model.Add("contactInfo", selectedContact);
        model.Add("contact", selectedContactInfo);
        return View["contact_info.cshtml", model];
      };
    }
  }
}
