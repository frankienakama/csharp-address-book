
using Nancy;
using System.Collections.Generic;

namespace AddressBook.Objects
{
  public class Contact{
    private string _contactName;
    private string _address;
    private string _phoneNumber;
    private int _id;
    private static List<Contact> _instances = new List<Contact>{};

    public Contact(string contactName, string contactAddress, string contactPhoneNumber)
    {
      _contactName = contactName;
      _address = contactAddress;
      _number = contactPhoneNumber;
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
    public string GetAddress()
    {
      return _address;
    }
    public void SetAddress(string newAddress)
    {
      _address = newAddress;
    }
    public string GetPhoneNumber()
    {
      return _phoneNumber;
    }
    public void SetPhoneNumber(string newPhoneNumber)
    {
      _phoneNumber = newPhoneNumber;
    }
    public int GetId()
    {
      return _id;
    }

//

    public static List<Contact> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static Contact Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}
