using RabbitMQ.Client;
using System.Text;

//Bağlantı oluşturma
ConnectionFactory factory = new();

factory.Uri = new ("amqps://qoxhlkik:yO2iEwKJ9VcxsAOHpV9cHKtAjPgK5O5D@gull.rmq.cloudamqp.com/qoxhlkik" );

//Bağlantıyı aktifleştirme ve kanal açma
using IConnection connection = factory.CreateConnection();
using IModel channel =  connection.CreateModel();

//Queue oluşturma 
channel.QueueDeclare(queue: "example-queue",exclusive:false); // exclusive; bu kuyruğun ozel olup olmadığını
// belirler.yani birden fazla bağlantı ile işlem yapılıp yapılmayacağını belirler.true ise ozeldir. 
// ozel ise bu bağlantı dışında hiçbir bağlantı bu kuyruğu kullanamayacak demektir. exclusive'in default'u truedur.

//Queue'ya mesaj gonderme
//rabbitmq kuyruğa atacağı mesajları, byte türünden kabul etmektedir.
//So,mesajı, byte çevirmeliyiz.
byte[] message = Encoding.UTF8.GetBytes("Merhaba");
channel.BasicPublish(exchange:"",routingKey:"example-queue",body:message);
//exchange boş, zaten default olarak direct change.
Console.Read();
