# Практическая работа 6

# СОЗДАНИЕ АВТОМАТИЗИРОВАННЫХ UNIT-ТЕСТОВ

## Создание проета банка и создание проекта модульного тестирования
![alt text](https://github.com/AndreyKorr1/Support_and_Testing_Software/blob/master/пр6_Bank/Изображения/image-1.png)

#### Создание методов для тестирования метода debit
![alt text](Изображения/image-2.png)
![alt text](image-4.png)
![alt text](image-5.png)

После создания запускаем тест
![alt text](image-6.png)

Тест не был проеден - требуется рефакторинг метода debit 

После рефакторинга:
Определили две константы 
```C#
public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";
public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";
```
Изменили два условных оператора в методе Debit

```C#
if (amount > m_balance)
{
    throw new System.ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage);
}

if (amount < 0)
{
    throw new System.ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);
}
```

Добавили также блок try/catch

Запускаем тест
![alt text](image-7.png)

Тесты показывают положительный результат

#### Создание методов для тестирования метода Credit

![alt text](image-8.png)

![alt text](image-9.png)

Запускаем тестирование 
![alt text](image-10.png)

Тесты показали положительный результат, следовательно рефакторинг не потребуется.