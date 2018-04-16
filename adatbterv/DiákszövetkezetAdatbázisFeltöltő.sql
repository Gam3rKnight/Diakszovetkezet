--Ezzel sz�rjuk be a felhaszn�l�kat
DELETE FROM StudentWork;
DELETE FROM StudentTime;
DELETE FROM Users;
DELETE FROM Work;
DELETE FROM Companies;

INSERT INTO Users (username,password,email,fname,lname,role,del) VALUES('fenyvesis', 'soma97', 'soma.fenyvesi@gmail.com', 'Soma', 'Fenyvesi',1,1);
INSERT INTO Users (username,password,email,fname,lname,role,del) VALUES('szatmarib', 'bela94', 'bela.szatmari@gmail.com', 'B�la', 'Szatm�ri',1,1);
INSERT INTO Users (username,password,email,fname,lname,role,del) VALUES('paksid', 'daniel97', 'daniel.paksi@gmail.com', 'D�niel', 'Paksi',1,1);
INSERT INTO Users (username,password,email,fname,lname,role,del) VALUES('nemethg', 'gabor96', 'gabor.nemeth@gmail.com', 'G�bor', 'N�meth',1,1);
INSERT INTO Users (username,password,email,fname,lname,role,del) VALUES('kissj', 'jozsef92', 'jozsef.kiss@gmail.com', 'J�zsef', 'Kiss',1,1);
INSERT INTO Users (username,password,email,fname,lname,role,del) VALUES('tothd', 'denes90', 'denes.toth@gmail.com', 'D�nes', 'T�th',1,1);
INSERT INTO Users (username,password,email,fname,lname,role,del) VALUES('nagyb', 'balazs89', 'balazs.nagy@gmail.com', 'Bal�zs', 'Nagy',1,1);
INSERT INTO Users (username,password,email,fname,lname,role,del) VALUES('szaboa', 'andras84', 'andras.szabo@gmail.com', 'Andr�s', 'Szab�',1,1);
INSERT INTO Users (username,password,email,fname,lname,role,del) VALUES('telekit', 'timea95', 'timea.teleki@hotmail.com', 'T�mea', 'Teleki',1,1);
INSERT INTO Users (username,password,email,fname,lname,role,del) VALUES('baranyia', 'andrea96', 'andrea.baranyi@freemail.hu', 'Andrea', 'Baranyi',1,1);
INSERT INTO Users (username,password,email,fname,lname,role,del) VALUES('root', 'root', 'root.root@root.com', 'root', 'root',0,1);
INSERT INTO Users (username,password,email,fname,lname,role,del) VALUES('diak', 'diak', 'diak@diak.com', 'diak', 'diak',1,1);
--Ezzel sz�rjuk be a c�geket

INSERT INTO Companies (c_id,c_name, location, c_description, c_del) VALUES((SELECT ISNULL(MAX(c_id)+1,0)FROM Companies WITH(SERIALIZABLE, UPDLOCK)),'HILTI Kft.','Kecskem�t','F�r�k, �tvef�r�k �s f�r�sz�rak k�sz�t�se.',1);
INSERT INTO Companies (c_id,c_name, location, c_description, c_del) VALUES((SELECT ISNULL(MAX(c_id)+1,0)FROM Companies WITH(SERIALIZABLE, UPDLOCK)),'Givaudan Hungary Kft.','Mak�','F�szer �s �tel �zes�t� gy�r.',1);
INSERT INTO Companies (c_id,c_name, location, c_description, c_del) VALUES((SELECT ISNULL(MAX(c_id)+1,0)FROM Companies WITH(SERIALIZABLE, UPDLOCK)),'Mercedes-Benz Hungary Kft.','Kecskem�t','Mercedes-Benz aut�k gy�rt�sa.',1);
INSERT INTO Companies (c_id,c_name, location, c_description, c_del) VALUES((SELECT ISNULL(MAX(c_id)+1,0)FROM Companies WITH(SERIALIZABLE, UPDLOCK)),'Continental Contitech Kft','V�c','Aut�gumi �s gumialkatr�szek gy�rt�sa.',1);
INSERT INTO Companies (c_id,c_name, location, c_description, c_del) VALUES((SELECT ISNULL(MAX(c_id)+1,0)FROM Companies WITH(SERIALIZABLE, UPDLOCK)),'HW St�di� Kft.','Kecskem�t','V�llalat ir�ny�t�si rendszerek fejleszt�se.',1);
INSERT INTO Companies (c_id,c_name, location, c_description, c_del) VALUES((SELECT ISNULL(MAX(c_id)+1,0)FROM Companies WITH(SERIALIZABLE, UPDLOCK)),'Gebr�der Weiss Sz�ll�tm�nyoz�si �s Logisztikai Kft.','Dunaharaszti','Fuvaroz�s, logisztika, fuvarszervez�s.',1);
INSERT INTO Companies (c_id,c_name, location, c_description, c_del) VALUES((SELECT ISNULL(MAX(c_id)+1,0)FROM Companies WITH(SERIALIZABLE, UPDLOCK)),'Hensel Hung�ria Villamoss�gi Kft.','Budapest','�rameloszot�k �s szab�lyoz�k gy�rt�sa fejleszt�se.',1);
INSERT INTO Companies (c_id,c_name, location, c_description, c_del) VALUES((SELECT ISNULL(MAX(c_id)+1,0)FROM Companies WITH(SERIALIZABLE, UPDLOCK)),'Audi Hung�ria Kft.','Gy�r','Audi motorok gy�rt�sa.',1);
INSERT INTO Companies (c_id,c_name, location, c_description, c_del) VALUES((SELECT ISNULL(MAX(c_id)+1,0)FROM Companies WITH(SERIALIZABLE, UPDLOCK)),'SMP','Kecskem�t','Aut� visszapillant� t�kr�k gy�rt�sa.',1);

--Ezzel sz�rjuk be a munk�kat

INSERT INTO Work (w_id,company_id,w_datestart,w_dateend,w_description,w_name,s_number) VALUES((SELECT ISNULL(MAX(w_id)+1,0)FROM Work WITH(SERIALIZABLE, UPDLOCK)),1,'2018-03-15 06:00:00', '2018-03-21 14:00:00', 'Fut�szallagn�l t�rt�n� munka. Betan�t�ssal egy�tt egy h�t.', 'Oper�tori munka', 5); 
INSERT INTO Work (w_id,company_id,w_datestart,w_dateend,w_description,w_name,s_number) VALUES((SELECT ISNULL(MAX(w_id)+1,0)FROM Work WITH(SERIALIZABLE, UPDLOCK)),3,'2018-03-17 08:00:00', '2018-03-19 16:20:00', 'S�rg�s adminisztr�ci�s feladatok elv�gz�se.', 'Irodai munka', 2); 
INSERT INTO Work (w_id,company_id,w_datestart,w_dateend,w_description,w_name,s_number) VALUES((SELECT ISNULL(MAX(w_id)+1,0)FROM Work WITH(SERIALIZABLE, UPDLOCK)),4,'2018-03-20 08:00:00', '2018-03-21 16:20:00', 'Pap�rok rendez�se, adminisztr�l�sa', 'Irodai munka', 1);
INSERT INTO Work (w_id,company_id,w_datestart,w_dateend,w_description,w_name,s_number) VALUES((SELECT ISNULL(MAX(w_id)+1,0)FROM Work WITH(SERIALIZABLE, UPDLOCK)),5,'2018-05-30 08:00:00', '2018-08-19 16:20:00', 'Ny�ri munk�ra keres�nk programoz� hallgat�kat', 'Programoz�',1);  
INSERT INTO Work (w_id,company_id,w_datestart,w_dateend,w_description,w_name,s_number) VALUES((SELECT ISNULL(MAX(w_id)+1,0)FROM Work WITH(SERIALIZABLE, UPDLOCK)),6,'2018-03-17 06:00:00', '2018-03-25 14:00:00', 'Dobozok pakol�sa, cimk�z�se', 'Oper�tori munka', 3); 
INSERT INTO Work (w_id,company_id,w_datestart,w_dateend,w_description,w_name,s_number) VALUES((SELECT ISNULL(MAX(w_id)+1,0)FROM Work WITH(SERIALIZABLE, UPDLOCK)),2,'2018-04-30 14:00:00', '2018-05-09 22:00:00', 'Csomagol� g�p kezel�se.', 'Oper�tori munka', 2); 
INSERT INTO Work (w_id,company_id,w_datestart,w_dateend,w_description,w_name,s_number) VALUES((SELECT ISNULL(MAX(w_id)+1,0)FROM Work WITH(SERIALIZABLE, UPDLOCK)),7,'2018-04-10 06:00:00', '2018-04-10 14:00:00', 'Alkatr�sz v�logat�s, rendez�s. Elektronikai v�gzetss�g el�ny!', 'Oper�tori munka', 1); 
INSERT INTO Work (w_id,company_id,w_datestart,w_dateend,w_description,w_name,s_number) VALUES((SELECT ISNULL(MAX(w_id)+1,0)FROM Work WITH(SERIALIZABLE, UPDLOCK)),1,'2018-03-15 06:00:00', '2018-03-21 14:00:00', 'Pap�rok rendez�se, adminisztr�ci�.', 'Irodai munka', 5); 
INSERT INTO Work (w_id,company_id,w_datestart,w_dateend,w_description,w_name,s_number) VALUES((SELECT ISNULL(MAX(w_id)+1,0)FROM Work WITH(SERIALIZABLE, UPDLOCK)),8,'2018-03-10 06:00:00', '2018-03-21 14:00:00', 'Angol nyelvismerettel rendelkez�t keres�nk ford�t�si munk�ra.', 'Iroda munka', 1); 
INSERT INTO Work (w_id,company_id,w_datestart,w_dateend,w_description,w_name,s_number) VALUES((SELECT ISNULL(MAX(w_id)+1,0)FROM Work WITH(SERIALIZABLE, UPDLOCK)),2,'2018-04-03 06:00:00', '2018-04-21 14:00:00', 'Rakt�roz�si munka', 'Oper�tori munka', 3); 


--Ezzel sz�rjuk be a di�kok idej�t
INSERT INTO StudentTime (s_id, s_username, datestart,dateend) VALUES((SELECT ISNULL(MAX(s_id)+1,0)FROM StudentTime WITH(SERIALIZABLE, UPDLOCK)),'fenyvesis', '2018-03-15 06:00:00', '2018-03-21 14:00:00');
INSERT INTO StudentTime (s_id, s_username, datestart,dateend) VALUES((SELECT ISNULL(MAX(s_id)+1,0)FROM StudentTime WITH(SERIALIZABLE, UPDLOCK)),'nemethg', '2018-03-18 08:00:00', '2018-03-20 16:20:00');
INSERT INTO StudentTime (s_id, s_username, datestart,dateend) VALUES((SELECT ISNULL(MAX(s_id)+1,0)FROM StudentTime WITH(SERIALIZABLE, UPDLOCK)),'szatmarib', '2018-03-20 06:00:00', '2018-03-25 14:00:00');
INSERT INTO StudentTime (s_id, s_username, datestart,dateend) VALUES((SELECT ISNULL(MAX(s_id)+1,0)FROM StudentTime WITH(SERIALIZABLE, UPDLOCK)),'kissj', '2018-05-30 08:00:00', '2018-07-31 16:20:00');
INSERT INTO StudentTime (s_id, s_username, datestart,dateend) VALUES((SELECT ISNULL(MAX(s_id)+1,0)FROM StudentTime WITH(SERIALIZABLE, UPDLOCK)),'tothd', '2018-03-17 06:00:00', '2018-03-25 14:00:00');
INSERT INTO StudentTime (s_id, s_username, datestart,dateend) VALUES((SELECT ISNULL(MAX(s_id)+1,0)FROM StudentTime WITH(SERIALIZABLE, UPDLOCK)),'nagyb', '2018-05-30 08:00:00', '2018-08-19 16:20:00');
INSERT INTO StudentTime (s_id, s_username, datestart,dateend) VALUES((SELECT ISNULL(MAX(s_id)+1,0)FROM StudentTime WITH(SERIALIZABLE, UPDLOCK)),'szaboa', '2018-04-30 14:00:00', '2018-05-06 22:00:00');
INSERT INTO StudentTime (s_id, s_username, datestart,dateend) VALUES((SELECT ISNULL(MAX(s_id)+1,0)FROM StudentTime WITH(SERIALIZABLE, UPDLOCK)),'telekit', '2018-04-08 06:00:00', '2018-04-18 14:00:00');
INSERT INTO StudentTime (s_id, s_username, datestart,dateend) VALUES((SELECT ISNULL(MAX(s_id)+1,0)FROM StudentTime WITH(SERIALIZABLE, UPDLOCK)),'baranyia', '2018-04-01 06:00:00', '2018-04-18 14:00:00');
INSERT INTO StudentTime (s_id, s_username, datestart,dateend) VALUES((SELECT ISNULL(MAX(s_id)+1,0)FROM StudentTime WITH(SERIALIZABLE, UPDLOCK)),'paksid', '2018-03-10 06:00:00', '2018-03-21 14:00:00');
