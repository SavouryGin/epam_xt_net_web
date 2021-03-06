﻿using System.Collections.Generic;

namespace Task_2_2_Adventure
{
	class Location
	{
		private string roomTitle;
		private string roomDescription;
		private List<Exit> exits;
		private List<Item> inventory;

		public Location()
		{
			// Описание на старте
			roomTitle = "";
			roomDescription = "";
			exits = new List<Exit>();
			inventory = new List<Item>();
		}

		public Location(string title)
		{
			roomTitle = title;
			roomDescription = "";
			exits = new List<Exit>();
			inventory = new List<Item>();
		}

		public Location(string title, string description)
		{
			roomTitle = title;
			roomDescription = description;
			exits = new List<Exit>();
			inventory = new List<Item>();
		}

		public override string ToString()
		{
			return roomTitle;
		}

		public void addExit(Exit exit)
		{
			exits.Add(exit);
		}

		public void removeExit(Exit exit)
		{
			if (exits.Contains(exit))
			{
				exits.Remove(exit);
			}
		}

		public List<Exit> getExits()
		{
			return new List<Exit>(exits);
		}

		public List<Item> getInventory()
		{
			return new List<Item>(inventory);
		}

		public void addItem(Item itemToAdd)
		{
			inventory.Add(itemToAdd);
		}

		public void removeItem(Item itemToRemove)
		{
			if (inventory.Contains(itemToRemove))
			{
				inventory.Remove(itemToRemove);
			}
		}

		public Item takeItem(string name)
		{
			foreach (Item _item in inventory)
			{
				if (_item.Name.ToLower() == name)
				{
					Item temp = _item;
					inventory.Remove(temp);
					return temp;
				}
			}

			return null;
		}

		public string getTitle()
		{
			return roomTitle;
		}

		public void setTitle(string title)
		{
			roomTitle = title;
		}

		public string getDescription()
		{
			return roomDescription;
		}

		public void setDescription(string description)
		{
			roomDescription = description;
		}
	}
}
