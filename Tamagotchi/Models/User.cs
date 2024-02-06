using System;
using System.Timers;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using Tamagotchis.Models;

namespace Tamagotchis.Models
{
  public class User
  {
    public string UserName { get; set; }
    public int UserId { get; set; }

    public static List<Pet> Pets { get; set; }

    private static List<User> _instances = new List<User> { };

    public User()
    {
      Pets = new List<Pet>();

      _instances.Add(this);
    }

    public void AddPet(Pet pet)
    {
      Pets.Add(pet);
    }

    public static List<User> GetAll()
    {
      return _instances;
    }

    public static void Add(User user)
    {
      _instances.Add(user);
    }

    public static User Find(int userId)
    {
      return _instances.FirstOrDefault(u => u.UserId == userId);
    }

    public static void Delete(int userId)
    {
      var userToDelete = _instances.FirstOrDefault(u => u.UserId == userId);
      if (userToDelete != null)
      {
        _instances.Remove(userToDelete);
      }
    }

  }
}

//leetcode nonsense

const input1 = "leetcode";

function firstCharFinder(string)
{
  let strArray = string.split();
  let storeAns = [];
  for (i = 0; i < strArray.length; i++)
  {
    for (j = i + 1; j < strArray.length; j++)
    {
      if (strArray[i] != strArray[j])
      {
        storeAns.push(i);
      }
    }
    else
    {
      storeAns.push(-1);
    }
  }
  return storeAns[0];
}

//the above doesn't work and sucks

function firstUniqChar(s)
{
  const charCount = { }; // Object to store character frequencies

  // First pass to count characters
  for (let i = 0; i < s.length; i++)
  {
    const char = s[i];
    if (charCount[char] === undefined)
    {
      charCount[char] = 1; // Initialize if the character hasn't been seen
    }
    else
    {
      charCount[char] += 1; // Increment the count if the character has been seen
    }
  }

  // Second pass to find the first unique character
  for (let i = 0; i < s.length; i++)
  {
    if (charCount[s[i]] === 1)
    {
      return i; // Return the index of the first unique character
    }
  }

  return -1; // Return -1 if there is no such character
}
