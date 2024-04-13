create table
  if not exists LINKS (
    ID string primary key,
    URL text not null,
    CLICKS text not null,
  );