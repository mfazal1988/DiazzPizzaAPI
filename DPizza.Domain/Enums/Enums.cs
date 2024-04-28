using System;
using System.Collections.Generic;
using System.Text;

namespace DPizza.Domain.Enums
{
    public enum EnumUserType    
    {
        None = 0,
        Administrator = 1, 
        SalesPerson = 2, 
        DeliveryPerson = 3, 
        Customer = 4
    }

    public enum EnumOrderStatus
    {
        None = 0,
        OrderReceived = 1, 
        OrderProcessing = 2, 
        ReadyToDelivery = 3, 
        Delivered = 4, 
        Cancelled = 5
    }

    public enum EnumCrustType
    { 
        None = 0,
        Pan = 1,
        Sausage
    }

    public enum EnumOrderType
    {
        None = 0,
        Delivery = 1, 
        Takeaway
    }

    public enum EnumPaymentStatus
    {
        None = 0,
        Success = 1, 
        Failed, 
        Pending, 
        Error, 
        Cancelled
    }

    public enum EnumPaymentType
    {
        None = 0,
        MasterVisa = 1,
        AmericanExpress = 2,
        CashOnDelivery = 3,
    }

    public enum EnumProductVarient
    {
        None = 0,
        Regular = 1, 
        Medium, 
        Large, 
        Pcs6, 
        Pcs12
    }

}
