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
      Get["/contacts/new"] = _ => {
        return View["contact_form.cshtml"];
      };
      Post["/contacts"] = _ => {
        var newContact = new Contact(Request.Form["contact-name"]);
        var allContacts = Contact.GetAll();
        return View["contacts.cshtml", allContacts];
      };
      Get["/contacts/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var selectedContact = Contact.Find(parameters.id);
        var contactNames = selectedContact.GetNames();
        model.Add("contact", selectedContact);
        model.Add("names", contactNames);
        return View["contact.cshtml", model];
      };
      Get["/contacts/{id}/names/new"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Contact selectedContact = Contact.Find(parameters.id);
        List<Name> allNames = selectedContact.GetNames();
        model.Add("contact", selectedContact);
        model.Add("names", allNames);
        return View["contact_names_form.cshtml", model];
      };
      Post["/names"] = _ => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Contact selectedContact = Contact.Find(Request.Form["contact-id"]);
        List<Name> contactNames = selectedContact.GetNames();
        string nameDescription = Request.Form["name-description"];
        Name newName = new Name(nameDescription);
        contactNames.Add(newName);
        model.Add("names", contactNames);
        model.Add("contact", selectedContact);
        return View["contact.cshtml", model];
      };
    }
  }
}
