-- Из задания не была до конца понятна структура таблиц - нужны ли отдельные идентификаторы для категорий и продуктов.
-- Таким образом решений может быть несколько:
-- Вариант 1. При отсутствии отдельного первичного ключа в виде числового идентификатора достаточно сделать выборку по одной таблице:
IF OBJECT_ID('product') IS NOT NULL
	DROP TABLE product;

IF OBJECT_ID('category') IS NOT NULL
	DROP TABLE category;

-- Справочная таблица категорий
CREATE TABLE category (
  name	VARCHAR(128) PRIMARY KEY
);

-- Таблица продуктов
CREATE TABLE product (
  name	VARCHAR(128) PRIMARY KEY,
  category VARCHAR(128) REFERENCES category (name)
);

-- Запрос на получение всех пар продукт-категория
SELECT
	name,
    category
FROM product
ORDER BY category;


-- Вариант 2. При наличии отдельного первичного ключа в виде числового идентификатора необходимо применить соединение таблиц:
IF OBJECT_ID('product') IS NOT NULL
	DROP TABLE product;

IF OBJECT_ID('category') IS NOT NULL
	DROP TABLE category;

-- Справочная таблица категорий
CREATE TABLE category (
  category_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  name	VARCHAR(128) UNIQUE
);

-- Таблица продуктов
CREATE TABLE product (
  product_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  name	VARCHAR(128) UNIQUE,
  category INT REFERENCES category (category_id)
);

-- Запрос на получение всех пар продукт-категория
SELECT
	p.name,
    c.name
FROM product AS p
LEFT JOIN category AS c
	ON p.category = c.category_id
ORDER BY c.name;