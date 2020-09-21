function CheckInteger(allowNegative) {
	if ((event.keyCode >= 48 && event.keyCode <= 57 && event.shiftKey == false) ||
		// 0-9 numbers        
        (event.keyCode >= 96 && event.keyCode <= 105 && event.shiftKey == false) ||
		// 0-9 numbers (the numeric keys at the right of the keyboard)
        (event.keyCode >= 37 && event.keyCode <= 40) || // Left, Up, Right and Down        
        event.keyCode == 8 || // backspaceASKII
        event.keyCode == 9 || // tabASKII
        event.keyCode == 16 || // shift
        event.keyCode == 17 || // control
        event.keyCode == 35 || // End
        event.keyCode == 36 || // Home
        event.keyCode == 46) // deleteASKII
		return true;
	else if (event.keyCode == 189 && allowNegative == true) { // dash (-)
		if (sender.value.indexOf('-', 0) > -1)
			return false;
		else
			return true;
	}
	else
		return false;
}
function CheckDecimal(sender, numberOfInteger, numberOfFrac, allowNegative) {
	var valueArr;

	if ((event.keyCode >= 37 && event.keyCode <= 40) || // Left, Up, Right and Down
        event.keyCode == 8 || // backspaceASKII
        event.keyCode == 9 || // tabASKII
        event.keyCode == 16 || // shift
        event.keyCode == 17 || // control
        event.keyCode == 35 || // End
        event.keyCode == 36 || // Home
        event.keyCode == 46) // deleteASKII
		return true;
	else if (event.keyCode == 189 && allowNegative == true) { // dash (-)
		if (sender.value.indexOf('-', 0) > -1)
			return false;
		else
			return true;
	}

	valueArr = sender.value.split('.');

	if (event.keyCode == 190) { // decimal point (.)
		if (valueArr[0] != null && valueArr[1] == null)
			return true;
		else
			return false;
	}

	if ((event.keyCode >= 48 && event.keyCode <= 57 && event.shiftKey == false) ||
		// 0-9 numbers        
        (event.keyCode >= 96 && event.keyCode <= 105 && event.shiftKey == false)) {
		// 0-9 numbers (the numeric keys at the right of the keyboard)
		if (valueArr[1] == null) {
			if (valueArr[0].indexOf('-', 0) > -1)
				numberOfInteger++;

			if (valueArr[0].length <= numberOfInteger)
				return true;
		}
		else {
			if (valueArr[1].length <= numberOfFrac)
				return true;
		}
	}

	return false;
}
function CheckNegative(sender) {
	if (event.keyCode == 189) { // dash (-)
		if (sender.value.indexOf('-', 0) > 0)
			sender.value = sender.value.replace('-', '');
	}
}