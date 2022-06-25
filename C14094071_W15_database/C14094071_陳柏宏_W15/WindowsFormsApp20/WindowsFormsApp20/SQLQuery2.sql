INSERT INTO 學號_宿舍 (學號,宿舍) VALUES ('F12345678',N'不存在宿舍');
INSERT INTO 學號_宿舍 (學號,宿舍) VALUES ('C14094071',N'勝利');
--INSERT INTO 姓名_學號_系級 (姓名,學號,系級) VALUES (N'不存在的人','F12345678',N'資訊777');
INSERT INTO 姓名_學號_系級(姓名,學號,系級) VALUES (N'陳柏宏','C14094071',N'不分113');
--INSERT INTO 姓名_期中考成績(姓名,期中考成績) VALUES (N'不存在的人',100);
INSERT INTO 姓名_期中考成績(姓名,期中考成績) VALUES (N'陳柏宏',49);
--DELETE FROM 學號_宿舍 WHERE 學號='F12345678'
--DELETE FROM 學號_宿舍 WHERE 學號='C14094071'
--DELETE FROM 姓名_學號_系級 WHERE 姓名=N'不存在的人'
--DELETE FROM 姓名_學號_系級 WHERE 姓名=N'陳柏宏'
--DELETE FROM 姓名_期中考成績 WHERE 姓名=N'不存在的人'
--DELETE FROM 姓名_期中考成績 WHERE 姓名=N'陳柏宏'
SELECT * From 學號_宿舍
SELECT * From 姓名_學號_系級
SELECT * From 姓名_期中考成績
/*
UPDATE 學號_宿舍
SET 宿舍 = N'光復'
WHERE 學號='F12345678'
UPDATE 姓名_學號_系級
SET 系級 = N'資訊123'
WHERE 姓名=N'不存在的人'
UPDATE 姓名_期中考成績
SET 期中考成績 = 105
WHERE 姓名=N'不存在的人'
*/
