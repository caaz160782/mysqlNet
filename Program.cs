namespace ConnectionMysql;

class Program{
    static void Main(){
        Conectar conectar=new Conectar();
        conectar.ReadBD();
       // conectar.InsertDb("Carlos");
       //conectar.InsertDb2("Hector Aguirre");
      // conectar.updateDb("Carlos Aguirre",3);
      conectar.DeleteDb(1);
       Console.WriteLine("___________________________");
       conectar.ReadBD();
    }
}

