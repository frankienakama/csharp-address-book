
using Nancy;
using System.Collections.Generic;
using AddressBook.Objects;

namespace AddressBook.Objects
{
  public class Contact
  {
    private string _contact
    private int _id;
    private static List<Contact> _instances = new List<Contact>{};

    public Contact (string contact)
    {
      _contact = contact;
      _instances.Add(this);
      _id = _instances.Count;
    }
    public string GetContact()
    {
      return _contact;
    }
    public void SetContact(string newContact)
    {
      _contact = newContact;
    }
    public static List<Contact> GetAll()
    {
      return _instancesl
    }
    public int GetId()
    {
      return _id;
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }
  }
}
