
using Nancy;
using System.Collections.Generic;
using AddressBook.Objects;

namespace AddressBook.Objects
{
  public class Contact
  {
    private string _contact;
    private int _id;
    private static List<Contact> _instances = new List<Contact>{};
    private List<Contact> _entries;

    public Contact (string contact)
    {
      _contact = contact;
      _instances.Add(this);
      _id = _instances.Count;
      _entries = new List<Contact>{};
    }
    public string GetContact()
    {
      return _contact;
    }
    public void SetContact(string newContact)
    {
      _contact = newContact;
    }
    public int GetId()
    {
      return _id;
    }
    public List<Contact> GetEntries()
    {
      return _entries;
    }
    public void AddContact(Contact contactInput)
    {
      _entries.Add(contactInput);
    }
    public static List<Contact> GetAll()
    {
      return _instances;
    }
    public static ContactInfo Find(int searcId)
    {
      return _instances[searchId-1];
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
