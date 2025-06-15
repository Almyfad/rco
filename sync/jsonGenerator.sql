DROP PROCEDURE IF EXISTS gen_json_object_expr;
DELIMITER $$

CREATE PROCEDURE gen_json_object_expr(
  IN p_table VARCHAR(64),
  IN p_prefix VARCHAR(10)
)
BEGIN
  DECLARE done INT DEFAULT FALSE;
  DECLARE col_name VARCHAR(64);
  DECLARE json_parts TEXT DEFAULT '';
  DECLARE cur CURSOR FOR
    SELECT COLUMN_NAME
    FROM INFORMATION_SCHEMA.COLUMNS
    WHERE TABLE_NAME = p_table
      AND TABLE_SCHEMA = DATABASE();
  DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;

  OPEN cur;

  read_loop: LOOP
    FETCH cur INTO col_name;
    IF done THEN
      LEAVE read_loop;
    END IF;

    IF json_parts = '' THEN
      SET json_parts = CONCAT('\'', col_name, '\', ', p_prefix, col_name);
    ELSE
      SET json_parts = CONCAT(json_parts, ', \'', col_name, '\', ', p_prefix, col_name);
    END IF;
  END LOOP;

  CLOSE cur;

  SELECT CONCAT('JSON_OBJECT(', json_parts, ')') AS json_expr;
END$$

DELIMITER ;
