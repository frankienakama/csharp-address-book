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
        List<Contact> allContacts = Contact.GetAll();
        return View["index.cshtml", allContacts];
      };
      Get["/contact/add"] = _ => {
        return View["add_contact.cshtml"];
      };
      Post["/contact/add"] = _ => {
        Contact newContact = new Contact(Request.Form["add-contact"], Request.Form["add-phoneNumber"], Request.Form["add-address"]);
        return View["new_contact_confirmation.cshtml", newContact];
      };
      Get["/contacts/{id}"] = parameters => {
        Contact contact = Contact.Find(parameters.id);
        return View["contact_info.cshtml", contact];
      };
      Post["/contacts/clear"] = _ => {
        Contact.ClearAll();
        return View["cleared.cshtml"];
      };
    }
  }
}
