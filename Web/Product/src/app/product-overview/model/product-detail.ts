export interface IProductDetail {
    id:any;
    productName:string;
    description:string;
    isActive:boolean;
    priceDetail:IPriceDetail;
}

export interface IPriceDetail{
    id:any;
    price:number;
    productId:any;
    isActive:boolean;
}
