
using Nancy;
using System.Collections.Generic;
using AddressBook.Objects;

namespace AddressBook.Objects
{
  public class Contact
  {
    private static List<Contact> _instances = new List<Contact> {};
    private string _name;
    private int _id;
    private List<ContactInfo> _input;

    public Contact(string contactName)
    {
      _name = contactName;
      _instances.Add(this);
      _id = _instances.Count;
      _input = new List<ContactInfo>{};
    }
    public string GetName()
    {
      return _name;
    }
    public int GetId()
    {
      return _id;
    }
    public List<ContactInfo> GetInfo()
    {
      return _input;
    }
    public void AddContact(ContactInfo contactInfo)
    {
      _input.Add(contactInfo);
    }
    public static List<Contact> GetAll()
    {
      return _instances;
    }
    public static void Clear()
    {
      _instances.Clear();
    }
    public static Contact Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}
