
using Nancy;
using System.Collections.Generic;
using AddressBook.Objects;

namespace AddressBook.Objects
{
  public class ContactInfo
  {
    private string _contactName;
    private string _contactPhoneNumber;
    private string _contactAddress;
    private int _id;
    private static List<Contact> _instances = new List<Contact>{};

    public Contact (string contactName, string contactPhoneNumber, string contactAddress)
    {
      _contactName = contactName;
      _contactPhoneNumber = contactPhoneNumber;
      _contactAddress = contactAddress;
      _instances.Add(this);
      _id = _instances.Count;
    }
    public string GetContactName()
    {
      return _contactName;
    }

    public void SetContactName(string newContactName)
    {
      _contactName = newContactName;
    }
    public string GetContactPhoneNumber()
    {
      return _contactPhoneNumber;
    }

    public void SetContactPhoneNumber(string newContactPhoneNumber)
    {
      _contactPhoneNumber = newContactPhoneNumber;
    }
    public string GetContactAddress()
    {
      return _contactAddress;
    }

    public void SetContactAddress(string newContactAddress)
    {
      _contactAddress = newContactAddress;
    }
    public static List<Contact> GetAll()
    {
      return _instances;
    }
    public int GetId()
    {
      return _id;
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }
    public static Contact Find(int searchId)
    {
      return _instances[searchId - 1];
    }
    }
  }
}
