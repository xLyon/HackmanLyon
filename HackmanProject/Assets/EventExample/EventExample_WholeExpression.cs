using System;
using UnityEngine;

//事件模型的[五个组成部分]
//事件的拥有者【Class】------>Class Customer
//事件【event关键字修饰】------>OnOrder, 点餐事件
//事件的响应者【Class】------> Class Waiter
//事件的订阅关系【+=】 ------> +=

//public delegate void OrderEventHandler(Customer _customer, OrderEventArgs _e);//为OnOder事件声明委托

public class EventExample_WholeExpression : MonoBehaviour
{
    Customer customer = new Customer();
    private Waiter waiter = new Waiter();

    private void Start()
    {
        customer.OnOrder += waiter.GiveBill;
        customer.Order("Mocha","Grand",32);
        customer.PayTheBill();
    }
}

public class Customer
{
    public float Bill { get; set; }

    public void PayTheBill()
    {
        Debug.Log("I have to pay:" + this.Bill);
    }

    //事件的【完整声明格式】,不常用
    //private OrderEventHandler orderEventHandler;
    //public event OrderEventHandler OnOrder
    //{
    //    add { orderEventHandler += value;}//添加事件处理器
    //    remove { orderEventHandler -= value;}//移除事件处理器
    //}

    //事件的【简略声明格式】(syn sugar)
    //looks like a delegate field but actually not
    //public event OrderEventHandler OnOrder;
    
    //使用微软自带的EventHandler来写
    public event EventHandler OnOrder;

    public void Order(string _name,string _size, float _price)
    {
        //【完整】
        //如果为空，则说明我们的委托类型字段orderEventHandler中没有储存任何其他方法的引用，没有人去订阅你
        //if (orderEventHandler != null)
        //{
        //    OrderEventArgs e = new OrderEventArgs();
        //    e.CoffeeName = "Mocha";
        //    e.CoffeePrize = 28;
        //    e.CoffeeSize = "Tall";
        //    orderEventHandler(this, e);
        //}

        //【简略】
        //Because if we simply assign a event, so we don't have the delegate field(orderEventHandler)
        //So we need to replace all orderEventHandler with the name of the Event(OnOrder)
        if (OnOrder != null)
        {
            OrderEventArgs e = new OrderEventArgs();
            e.CoffeeName = _name;
            e.CoffeePrize = _price;
            e.CoffeeSize = _size;
            OnOrder(this, e);
        }

    }
}

public class OrderEventArgs : EventArgs
{
    public string CoffeeName { get; set; }
    public string CoffeeSize { get; set; }
    public float CoffeePrize { get; set; }
}

//事件订阅者
public class Waiter
{
    //事件处理器
    //public void GiveBill(Customer _customer, OrderEventArgs _e)
    //{
    //    float finalPrice = 0;
    //    switch (_e.CoffeeSize)
    //    {
    //        case "Tall":
    //            finalPrice = _e.CoffeePrize;
    //            break;
    //        case "Grand":
    //            finalPrice = _e.CoffeePrize + 3;
    //            break;
    //        case "Venti":
    //            finalPrice = _e.CoffeePrize + 6;
    //            break;
    //    }
    //    _customer.Bill += finalPrice;
    //}
    internal void GiveBill(object _sender, EventArgs _e)
    {
        Customer customer = _sender as Customer;
        OrderEventArgs e = _e as OrderEventArgs;

        float finalPrice = 0;
        switch (e.CoffeeSize)
        {
            case "Tall":
                finalPrice = e.CoffeePrize;
                break;
            case "Grand":
                finalPrice = e.CoffeePrize + 3;
                break;
            case "Venti":
                finalPrice = e.CoffeePrize + 6;
                break;
        }
        customer.Bill += finalPrice;
    }
}
