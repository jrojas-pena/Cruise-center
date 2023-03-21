--Author: Juan Rojas
create or replace 
PROCEDURE CREATE_RESERVATION(
    pship_id IN NUMBER,
    pcabin_no IN NUMBER,
    preservation_id OUT NUMBER
)
IS
    pcount NUMBER;
BEGIN
    SELECT COUNT(*) INTO pcount FROM reservation WHERE ship_id = pship_id AND cabin_no = pcabin_no;
    IF pcount = 0 THEN
        SELECT reservation_id_sequence.NEXTVAL INTO preservation_id FROM dual;
        INSERT INTO reservation (reservation_id, ship_id, traveller_id, cabin_no) VALUES (preservation_id, pship_id, (SELECT USER FROM dual), pcabin_no);
    ELSE
        preservation_id := 0;
    END IF;
END;