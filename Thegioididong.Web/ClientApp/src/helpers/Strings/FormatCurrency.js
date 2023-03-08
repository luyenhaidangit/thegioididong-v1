const FormatCurrency = (amount) => {
    if (isNaN(amount) || !Number.isInteger(amount) || amount < 0) {
        throw new Error('Invalid input: Amount must be a non-negative integer');
    }

    return amount.toLocaleString('vi-VN', { style: 'currency', currency: 'VND' }).replace('₫', '') + '₫';

}

export default FormatCurrency;
