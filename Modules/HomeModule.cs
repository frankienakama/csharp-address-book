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
      Get["/contact/add"] = _ => {
        return View["add_a_new_contact.cshtml"];
      };
      Post["/"] = _ => {
        var newContact = new Contact(Request.Form["new-contact"]);
        var allContacts = Contact.GetAll();
        return View["index.cshtml", allContacts];
      };
      Get["/contact/{id}"] = parameters => {
        var selectedContact = Contact.Find(parameters.id);
        var currtentContact = selectedContact.GetContact();
        return View["index.cshtml", model];
      };

    }
  }
}
