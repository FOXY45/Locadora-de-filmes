/* Faça aqui as trigger.sql, aqui vai um exemplo para referencia:
-- Trigger para impedir inserção de funcionário com salário menor que 1000
CREATE TRIGGER VerificaSalarioMinimo
BEFORE INSERT ON Funcionarios
FOR EACH ROW
BEGIN
    SELECT 
        CASE 
            WHEN NEW.Salario < 1000 THEN
                RAISE(ABORT, 'Salário abaixo do mínimo permitido')
        END;
END;

*/