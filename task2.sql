-- �� ������� �� �뫠 �� ���� ����⭠ ������� ⠡��� - �㦭� �� �⤥��� �����䨪���� ��� ��⥣�਩ � �த�⮢.
-- ����� ��ࠧ�� �襭�� ����� ���� ��᪮�쪮:
-- ��ਠ�� 1. �� ������⢨� �⤥�쭮�� ��ࢨ筮�� ���� � ���� �᫮���� �����䨪��� �����筮 ᤥ���� �롮�� �� ����� ⠡���:
IF OBJECT_ID('product') IS NOT NULL
	DROP TABLE product;

IF OBJECT_ID('category') IS NOT NULL
	DROP TABLE category;

-- ��ࠢ�筠� ⠡��� ��⥣�਩
CREATE TABLE category (
  name	VARCHAR(128) PRIMARY KEY
);

-- ������ �த�⮢
CREATE TABLE product (
  name	VARCHAR(128) PRIMARY KEY,
  category VARCHAR(128) REFERENCES category (name)
);

-- ����� �� ����祭�� ��� ��� �த��-��⥣���
SELECT
	name,
    category
FROM product
ORDER BY category;


-- ��ਠ�� 2. �� ����稨 �⤥�쭮�� ��ࢨ筮�� ���� � ���� �᫮���� �����䨪��� ����室��� �ਬ����� ᮥ������� ⠡���:
IF OBJECT_ID('product') IS NOT NULL
	DROP TABLE product;

IF OBJECT_ID('category') IS NOT NULL
	DROP TABLE category;

-- ��ࠢ�筠� ⠡��� ��⥣�਩
CREATE TABLE category (
  category_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  name	VARCHAR(128) UNIQUE
);

-- ������ �த�⮢
CREATE TABLE product (
  product_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  name	VARCHAR(128) UNIQUE,
  category INT REFERENCES category (category_id)
);

-- ����� �� ����祭�� ��� ��� �த��-��⥣���
SELECT
	p.name,
    c.name
FROM product AS p
LEFT JOIN category AS c
	ON p.category = c.category_id
ORDER BY c.name;