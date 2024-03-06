create table Books
(
	Id serial primary key,
	Name varchar,
	Description varchar,
	Pages int,
	AnActive bool
);

drop table Books

create table Author
(
	AuthorId serial primary key,
	FullName varchar,
	Age int
);

create table Genre
(
	GenreId serial primary key,
	GenreName varchar
);

create table AuthorBooks
(
	AuthorId int references Author(AuthorId),
	BookId int references Books(Id)
);

create table GenreBook
(
	GenreId int references Genre(GenreId),
	BookId int references Books(Id)
);

insert into Author(FullName,Age)
            values('Mustafo',16),
			      ('Barotov',14),
				  ('Salom',19)

insert into Genre(GenreName)
           values('Roman'),
		         ('Sport')

select b.Id,b.Name,b.Description,a.AuthorId,a.Fullname 
from AuthorBooks as ab 
join Books as b on ab.BookId = b.Id
join Author as a on ab.AuthorId = a.AuthorId where a.AuthorId = 1

select b.Id,b.Name,b.Description,g.GenreId,g.GenreName
from GenreBook as gb
join Books as b on gb.BookId = b.Id
join Genre as g on gb.GenreId = g.GenreId
select * from Books





