--Ezzel szúrjuk be a felhasználókat
DELETE FROM StudentWork;
DELETE FROM StudentTime;
DELETE FROM Users;
DELETE FROM Work;
DELETE FROM Companies;

INSERT INTO Users (username,password,email,fname,lname,role,del) VALUES('fenyvesis', 'soma97', 'soma.fenyvesi@gmail.com', 'Soma', 'Fenyvesi',1,1);
INSERT INTO Users (username,password,email,fname,lname,role,del) VALUES('szatmarib', 'bela94', 'bela.szatmari@gmail.com', 'Béla', 'Szatmári',1,1);
INSERT INTO Users (username,password,email,fname,lname,role,del) VALUES('paksid', 'daniel97', 'daniel.paksi@gmail.com', 'Dániel', 'Paksi',1,1);
INSERT INTO Users (username,password,email,fname,lname,role,del) VALUES('nemethg', 'gabor96', 'gabor.nemeth@gmail.com', 'Gábor', 'Németh',1,1);
INSERT INTO Users (username,password,email,fname,lname,role,del) VALUES('kissj', 'jozsef92', 'jozsef.kiss@gmail.com', 'József', 'Kiss',1,1);
INSERT INTO Users (username,password,email,fname,lname,role,del) VALUES('tothd', 'denes90', 'denes.toth@gmail.com', 'Dénes', 'Tóth',1,1);
INSERT INTO Users (username,password,email,fname,lname,role,del) VALUES('nagyb', 'balazs89', 'balazs.nagy@gmail.com', 'Balázs', 'Nagy',1,1);
INSERT INTO Users (username,password,email,fname,lname,role,del) VALUES('szaboa', 'andras84', 'andras.szabo@gmail.com', 'András', 'Szabó',1,1);
INSERT INTO Users (username,password,email,fname,lname,role,del) VALUES('telekit', 'timea95', 'timea.teleki@hotmail.com', 'Tímea', 'Teleki',1,1);
INSERT INTO Users (username,password,email,fname,lname,role,del) VALUES('baranyia', 'andrea96', 'andrea.baranyi@freemail.hu', 'Andrea', 'Baranyi',1,1);
INSERT INTO Users (username,password,email,fname,lname,role,del) VALUES('root', 'root', 'root.root@root.com', 'root', 'root',0,1);
INSERT INTO Users (username,password,email,fname,lname,role,del) VALUES('diak', 'diak', 'diak@diak.com', 'diak', 'diak',1,1);
--Ezzel szúrjuk be a cégeket

INSERT INTO Companies (c_id,c_name, location, c_description, c_del) VALUES((SELECT ISNULL(MAX(c_id)+1,0)FROM Companies WITH(SERIALIZABLE, UPDLOCK)),'HILTI Kft.','Kecskemét','Fúrók, ütvefúrók és fúrószárak készítése.',1);
INSERT INTO Companies (c_id,c_name, location, c_description, c_del) VALUES((SELECT ISNULL(MAX(c_id)+1,0)FROM Companies WITH(SERIALIZABLE, UPDLOCK)),'Givaudan Hungary Kft.','Makó','Fûszer és étel ízesítõ gyár.',1);
INSERT INTO Companies (c_id,c_name, location, c_description, c_del) VALUES((SELECT ISNULL(MAX(c_id)+1,0)FROM Companies WITH(SERIALIZABLE, UPDLOCK)),'Mercedes-Benz Hungary Kft.','Kecskemét','Mercedes-Benz autók gyártása.',1);
INSERT INTO Companies (c_id,c_name, location, c_description, c_del) VALUES((SELECT ISNULL(MAX(c_id)+1,0)FROM Companies WITH(SERIALIZABLE, UPDLOCK)),'Continental Contitech Kft','Vác','Autógumi és gumialkatrészek gyártása.',1);
INSERT INTO Companies (c_id,c_name, location, c_description, c_del) VALUES((SELECT ISNULL(MAX(c_id)+1,0)FROM Companies WITH(SERIALIZABLE, UPDLOCK)),'HW Stúdió Kft.','Kecskemét','Vállalat irányítási rendszerek fejlesztése.',1);
INSERT INTO Companies (c_id,c_name, location, c_description, c_del) VALUES((SELECT ISNULL(MAX(c_id)+1,0)FROM Companies WITH(SERIALIZABLE, UPDLOCK)),'Gebrüder Weiss Szállítmányozási és Logisztikai Kft.','Dunaharaszti','Fuvarozás, logisztika, fuvarszervezés.',1);
INSERT INTO Companies (c_id,c_name, location, c_description, c_del) VALUES((SELECT ISNULL(MAX(c_id)+1,0)FROM Companies WITH(SERIALIZABLE, UPDLOCK)),'Hensel Hungária Villamossági Kft.','Budapest','Árameloszotók és szabályozók gyártása fejlesztése.',1);
INSERT INTO Companies (c_id,c_name, location, c_description, c_del) VALUES((SELECT ISNULL(MAX(c_id)+1,0)FROM Companies WITH(SERIALIZABLE, UPDLOCK)),'Audi Hungária Kft.','Gyõr','Audi motorok gyártása.',1);
INSERT INTO Companies (c_id,c_name, location, c_description, c_del) VALUES((SELECT ISNULL(MAX(c_id)+1,0)FROM Companies WITH(SERIALIZABLE, UPDLOCK)),'SMP','Kecskemét','Autó visszapillantó tükrök gyártása.',1);

--Ezzel szúrjuk be a munkákat

INSERT INTO Work (w_id,company_id,w_datestart,w_dateend,w_description,w_name,s_number) VALUES((SELECT ISNULL(MAX(w_id)+1,0)FROM Work WITH(SERIALIZABLE, UPDLOCK)),1,'2018-03-15 06:00:00', '2018-03-21 14:00:00', 'Futószallagnál történõ munka. Betanítással együtt egy hét.', 'Operátori munka', 5); 
INSERT INTO Work (w_id,company_id,w_datestart,w_dateend,w_description,w_name,s_number) VALUES((SELECT ISNULL(MAX(w_id)+1,0)FROM Work WITH(SERIALIZABLE, UPDLOCK)),3,'2018-03-17 08:00:00', '2018-03-19 16:20:00', 'Sûrgõs adminisztrációs feladatok elvégzése.', 'Irodai munka', 2); 
INSERT INTO Work (w_id,company_id,w_datestart,w_dateend,w_description,w_name,s_number) VALUES((SELECT ISNULL(MAX(w_id)+1,0)FROM Work WITH(SERIALIZABLE, UPDLOCK)),4,'2018-03-20 08:00:00', '2018-03-21 16:20:00', 'Papírok rendezése, adminisztrálása', 'Irodai munka', 1);
INSERT INTO Work (w_id,company_id,w_datestart,w_dateend,w_description,w_name,s_number) VALUES((SELECT ISNULL(MAX(w_id)+1,0)FROM Work WITH(SERIALIZABLE, UPDLOCK)),5,'2018-05-30 08:00:00', '2018-08-19 16:20:00', 'Nyári munkára keresünk programozó hallgatókat', 'Programozó',1);  
INSERT INTO Work (w_id,company_id,w_datestart,w_dateend,w_description,w_name,s_number) VALUES((SELECT ISNULL(MAX(w_id)+1,0)FROM Work WITH(SERIALIZABLE, UPDLOCK)),6,'2018-03-17 06:00:00', '2018-03-25 14:00:00', 'Dobozok pakolása, cimkézése', 'Operátori munka', 3); 
INSERT INTO Work (w_id,company_id,w_datestart,w_dateend,w_description,w_name,s_number) VALUES((SELECT ISNULL(MAX(w_id)+1,0)FROM Work WITH(SERIALIZABLE, UPDLOCK)),2,'2018-04-30 14:00:00', '2018-05-09 22:00:00', 'Csomagoló gép kezelése.', 'Operátori munka', 2); 
INSERT INTO Work (w_id,company_id,w_datestart,w_dateend,w_description,w_name,s_number) VALUES((SELECT ISNULL(MAX(w_id)+1,0)FROM Work WITH(SERIALIZABLE, UPDLOCK)),7,'2018-04-10 06:00:00', '2018-04-10 14:00:00', 'Alkatrész válogatás, rendezés. Elektronikai végzetsség elõny!', 'Operátori munka', 1); 
INSERT INTO Work (w_id,company_id,w_datestart,w_dateend,w_description,w_name,s_number) VALUES((SELECT ISNULL(MAX(w_id)+1,0)FROM Work WITH(SERIALIZABLE, UPDLOCK)),1,'2018-03-15 06:00:00', '2018-03-21 14:00:00', 'Papírok rendezése, adminisztráció.', 'Irodai munka', 5); 
INSERT INTO Work (w_id,company_id,w_datestart,w_dateend,w_description,w_name,s_number) VALUES((SELECT ISNULL(MAX(w_id)+1,0)FROM Work WITH(SERIALIZABLE, UPDLOCK)),8,'2018-03-10 06:00:00', '2018-03-21 14:00:00', 'Angol nyelvismerettel rendelkezõt keresünk fordítási munkára.', 'Iroda munka', 1); 
INSERT INTO Work (w_id,company_id,w_datestart,w_dateend,w_description,w_name,s_number) VALUES((SELECT ISNULL(MAX(w_id)+1,0)FROM Work WITH(SERIALIZABLE, UPDLOCK)),2,'2018-04-03 06:00:00', '2018-04-21 14:00:00', 'Raktározási munka', 'Operátori munka', 3); 


--Ezzel szúrjuk be a diákok idejét
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
