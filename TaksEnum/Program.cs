namespace ClassTaskEnum;
using Core.Helpers.Enums;
using Core.Models;
using System;
using System.Diagnostics;

internal class Program
{
    static void Main(string[] args)
    {
        int shortcut;
        bool f = true;
        int value1;
        int value2;
        Types? type=null;
        Types? type2 = null;
        Store store = new Store();
        string name;
        string name2;
        double price;
        string TypeNo;
        try
        {
            do
            {
                Console.WriteLine("Magazamiza xos geldiniz\n______________________________\nINFO: Asagidaki shorcuts dan istifade ederek istediyiniz emeliyyati icra ede bilersiniz");
                Console.WriteLine("Product add etmek ucun: 1\nRemove emeliyyati ucun: 2\nType gore filtirlemek ucun: 3\nProqrami dayandirmaq ucun: 0");
                Console.WriteLine("Secdiyiniz Shortcuti daxil edin:");
                shortcut = int.Parse(Console.ReadLine());
                switch (shortcut)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Product name daxil edin: ");
                        name = Console.ReadLine();
                        do
                        {
                            Console.Write("Price daxil edin:");
                             f = double.TryParse(Console.ReadLine(), out price);
                        } while (!f);
                        Console.WriteLine("Baker:1");
                        Console.WriteLine("Drink:2");
                        Console.WriteLine(" Meat:3");
                        Console.WriteLine("Diary:4");

                        Console.Write("Type secin:");

                        TypeNo = Console.ReadLine();
                        switch (TypeNo)
                        {
                            case "1":
                                type = Types.Baker; break;
                                case "2":
                                type = Types.Diary; break;
                                case "3":
                                    type = Types.Meat; break;
                                case "4":
                                    type = Types.Drink; break;
                            default:
                                Console.WriteLine("Duzgun secim edin. ");
                                break;
                        }
                        if (type != null)
                        {

                            Product product = new Product(name, price, type.Value);
                            store.AddProduct(product);
                            Console.WriteLine("BU Product elave olundu.");
                        }

                        else
                        {
                            Console.WriteLine("Product elave edilmedi.");
                        }
                        break;
                    case 2:
                        Console.Clear();
                        do
                        {
                            Console.Write("Silmek istediyiniz mehsulun no- girin:");

                            f = int.TryParse(Console.ReadLine(), out value1);
                            {
                                store.RemoveProductByNo(value1);
                                Console.WriteLine(" ");
                            }



                        } while (!f);
                        break;

                        case 3:
                        Console.Clear();

                        Console.WriteLine("Baker:1");
                        Console.WriteLine("Drink:2");
                        Console.WriteLine(" Meat:3");
                        Console.WriteLine("Diary:4");
                        Console.Write("Hansi type gore filterlemek isteyirsiniz?:");
                        TypeNo = Console.ReadLine();

                        switch (TypeNo)
                        {
                            case "1":
                                type2 = Types.Baker; break;
                            case "2":
                                type2 = Types.Drink; break;
                            case "3":
                                type2 = Types.Meat; break;
                            case "4": type2 = Types.Diary; break;
                            default:
                                Console.WriteLine("Duzgun secim edin!");
                                break;
                        }

                        if (type2 != null)
                        {

                            Product[] products = store.FilterProductsByType(type2.Value);
                            if (products.Length != 0)
                            {
                                for (int i = 0; i < products.Length; i++)
                                {
                                    
                                    Console.WriteLine($"{type2} tipi uzre, product adlari: {products[i].Name}\nProduct Nomreleri: {products[i].No}");
                                }
                            }

                            else
                            {
                                Console.WriteLine("Axtardiginiz typeda prodduct tapilmadi.");
                            }
                        }
                        break;
                        case 0:
                        Console.WriteLine("Proqram dayandirlidi.");
                        break;


                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }



            }
            while (shortcut != 0);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }



}

