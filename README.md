# SqlMethods
Eğitim sırasında proje geliştirirken her projenizde hazır olarak kullanabileceğiniz "select,insert,update,delete" methodlarını içeren bir sınıf oluşturdum.
Tek yapmanız gereken ilgili classı başka bir classta çağırırken new işlemi yaptığınız tarafta parantez içine sql bağlantınızı yazmanız. 
Daha sonrasında data grid doldurma işlemi yani tablo çağırma işlemi yapacaksanız SelectData methodunu çağırmanız ve parametre olarak çağırmak istediğiniz tablo adını yazmanız yeterlidir
AddData,UpdateData methodlarını çağıracağınızda ise parametre olarak yapmak istediğiniz sql sorgusunu yazmanız gerekmektedir.
DeleteData methodunda ise parametrelere tablo adı, kolon adı(id olması gerekir) ve silmek istediğiniz satıra ait olan int veri girmeniz yeterlidir.
