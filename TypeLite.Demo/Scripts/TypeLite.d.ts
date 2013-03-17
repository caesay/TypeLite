

 


module Eshop {
interface Product {
  Name: string;
  Price: number;
}
interface Order {
  Products: Product[];
  TotalPrice: number;
}
interface Customer {
  Name: string;
  Email: string;
  VIP: bool;
  Orders: Order[];
}
}
