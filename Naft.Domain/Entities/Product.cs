﻿
using System.Collections;
using Naft.Domain.ValueObjects;

namespace Naft.Domain.Entities;

public class Product : Entity 
{
    public Product(Title title, Description description, Price price, Quantity quantity, Image image, User user)
    {
        if (title == null || description == null || price == null || quantity == null  || user == null)
        {
            AddNotification("Product", "Produto inválido");
            return;
        }
        
        Title = title;
        Description = description;
        Price = price;
        Quantity = quantity;
        Image = image;
        Seller = user;
        _categories = new List<Category>();
        Active = true;
        
        AddNotifications(title, description, price, quantity, user);
    }
    
    public Title Title { get; private set; }
    public Description Description { get; private set; }
    public Price Price { get; private set; }
    public Quantity Quantity { get; private set; }
    
    public bool Active { get; private set; }
    public Image Image { get; private set; }
    
    public User Seller { get; private set; }
    public IEnumerable<Category> Categories => _categories;
    private IList<Category> _categories { get; set; }
    
    public bool AddCategory(Category category)
    {
        if (_categories.Contains(category))
            return false;
        
        _categories.Add(category);
        return true;
    }
    
    
    
}