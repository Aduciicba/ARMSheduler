create table DbVersion (
  version TEXT
, build TEXT
, last_update_time TEXT
);
 
create table EventType (
  id_event_type INTEGER PRIMARY KEY
, fid_event_type INTEGER
, name TEXT
);

insert into EventType (id_event_type, "fid_event_type","name")
values (1, null, 'Импорт');

insert into EventType (id_event_type, "fid_event_type","name")
values (2, null, 'Отправка уведомлений');

insert into EventType (id_event_type, "fid_event_type","name")
values (3, 2, 'Отправка уведомлений о графиках ПЗ');

insert into EventType (id_event_type, "fid_event_type","name")
values (4, 2, 'Отправка уведомлений о графиках МО');

insert into EventType (id_event_type, "fid_event_type","name")
values (5, 2, 'Отправка уведомлений о карточках СИЗ');

insert into EventType (id_event_type, "fid_event_type","name")
values (6, 2, 'Отправка уведомлений о компенсациях');

insert into EventType (id_event_type, "fid_event_type","name")
values (7, 2, 'Отправка уведомлений о карточках работников');


create table Event (
  id_event INTEGER PRIMARY KEY AUTOINCREMENT
, fid_event_type INTEGER NOT NULL
, start_week_days TEXT
, start_time TEXT 
, is_active TEXT
, FOREIGN KEY(fid_event_type) REFERENCES EventType(id_event_type)
);

insert into Event(fid_event_type, start_week_days, start_time)
values (1, '0000000', datetime('now', 'start of day'));

insert into Event(fid_event_type, start_week_days, start_time)
values (2, '0000000', datetime('now', 'start of day'));

create table EventEmail (
  id_event_email INTEGER PRIMARY KEY AUTOINCREMENT
, fid_event INTEGER NOT NULL
, email TEXT
, FOREIGN KEY(fid_event) REFERENCES Event(id_event)
);  

create table EventLog (
  id_event_log INTEGER PRIMARY KEY AUTOINCREMENT
, event_time DATETIME
, fid_event INTEGER NOT NULL
, event_state TEXT
, event_errors TEXT
, FOREIGN KEY(fid_event) REFERENCES Event(id_event)
);
  
insert into DbVersion("version","build","last_update_time")
values (1, 0, datetime('now'));
