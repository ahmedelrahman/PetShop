   M S B A M L   `   `   `  ????B  >PetShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:PetShopPetShop  5   	       PetShop.shopCart   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:PetShop     5   	     ? Title$  shopCart??5   	   $	??450??6   $	??800??6'    ? 	Resources 5
         ProductTemplate ?? Orientation ?? TextWrapping??%  &	        ?? 5   
   .R?5      ?? $ 
Horizontal=?6   .+?5      ?? $??5q?65   $??75??6@   $??60??6K   ??6   ?? *	ImagePath+6K   ?? 5      .+?5      ?? $??Arial)?66   $??14(?6I   $
??Bold"?6W   ??6    ?? *Name+6W   ?? 5      $	??200??6=   $
??Wrap=?6I   ??6    ?? *Description+6I   ?? 5      $	??200??67   $
??Wrap=?6C   ??6    ?? *Price+6C   ?? 5      $??40??6?   $
 Wrap=?6J   {?. ??6   ?? *PurchasedAmount+6^   5      5      5      5      .??5      ?? $	??422??6   $??0,0,0.286,-0.286q?6   $??Bottom=?68   .+?5   
   ?? #??[  6<   $
??Auto=?5      $	??400??6B   $	??319??6R   $??0,0,-0.286,0q?6_   ??5      ?? *Parent.cContents+5   _   ?? 5   
   $ 
Horizontal=?6   $??Center=?6.   .+?5      ?? $??Total??6   $??25??6$   $??75??60   ?? 5      $??25??6@   $	??100??6L   ??6   ?? *Parent.TotalCostDisplay+6L   5      ?? 5   
   $ vertical=?6   .+?5       ?? $??Center=?6   $ 
Horizontal=?66   .+?5!      ?? $??Center=?6   $??Update Quantities??66   $??25??6R   $	??125??6^   ??6j   ?? *UpdateCartCommand+5#      ?? 5%      $Q??KTo delete an item: set it's quantity value to 0 and click Update Quantities??6   $??Center=?6j   ?? 5&      $????Please do not input any numbers (except for the number 0) in the small textbox next to each item. It is only intended to serve the delete purpose.??6   $??Center=?6?   5'      5)      5*      