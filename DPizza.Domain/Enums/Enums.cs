using System;
using System.Collections.Generic;
using System.Text;

namespace DPizza.Domain.Enums
{
    public enum EnumUserType    
    {
        Administrator = 1, 
        SalesPerson = 2, 
        DeliveryPerson = 3, 
        Customer = 4
    }

    public enum EnumOrderStatus
    {
        OrderReceived = 1, 
        OrderProcessing = 2, 
        ReadyToDelivery = 3, 
        Delivered = 4, 
        Cancelled = 5
    }

    public enum EnumCrustType
    { 
        Pan = 1,
        Sausage
    }

    public enum EnumOrderType
    {
        Delivery = 1, 
        Takeaway
    }

    public enum EnumPaymentStatus
    {
        Success = 1, 
        Failed, 
        Pending, 
        Error, 
        Cancelled
    }

    public enum EnumPaymentType
    {
        MasterVisa = 1,
        AmericanExpress = 2,
        CashOnDelivery = 3,
    }

    public enum EnumProductVarient
    {
        Regular = 1, 
        Medium, 
        Large, 
        Pcs6, 
        Pcs12
    }

}
