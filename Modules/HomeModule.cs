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
      // Post["/contact/add"] = _ => {
      //   var addContact = new Contact(Request.Form["new-contact"]);
      //   return View["new_contact_confirmation.cshtml"];
      // };
      Post["/"] = _ => {
        var newContact = new Contact(Request.Form["new-contact"]);
        var allContacts = Contact.GetAll();
        return View["index.cshtml", allContacts];
      };
      Get["/contact/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var selectedContact = Contact.Find(parameters.id);
        var currentContact = selectedContact.GetContact();
        model.Add("contact", selectedContact);
        model.Add("currentContactInfo", currentContact);
        return View["index.cshtml", model];
      };
      Post["/contact/new"] = _ => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        string selectedContact = Contact.Find(Request.Form["new-contact"]);
        List<Contact> currentContact = selectedContact.GetAddressBookEntries();
        string newContactInfo = Request.Form["new-contact"];
        Contact newContact = new Contact(newContactInfo);
        currentContact.Add(newContact);
        model.Add("contact", currentContact);
        model.Add("currentContactInfo", selectedContact);
        return View["new_contact_confirmation.cshtml"];
      };
    }
  }
}
