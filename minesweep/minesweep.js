rows = 10;
cols = 10;
mines = 10;

function onLoad() {
	fieldElement = document.getElementById('field');
	var str = '';
	for(var  i = 0 ; i < rows ; i++) {
		str += '<div>';
		for(var j = 0 ; j < cols ; j++)  {
			str+='<button>X</button>';
		}
		str += '</div>';
	}
	
	field.innerHTML = str;
	for(var i = 0 ; i < rows ; i++) {
		for(var j = 0 ; j < cols ; j++)  {
			var divElem =fieldElement.childNodes[i];
			var button = divElem.childNodes[j];
			button.onclick = make_onclick({x:i,y:j});
		}
	}
	
	field = new Array;
	for(var i = 0 ; i < rows ; i++) {
		field[i]  = new Array;
		for(var j = 0 ; j < cols ; j++)  {	
			field[i][j] = false;
		}
	}

	
	
	var placedMines = 0;
	while (placedMines< mines) {
		var x =  Math.floor(Math.random()*cols);
		var y =  Math.floor(Math.random()*rows);
		if (field[y][x] == true) 
			continue;
		field[y][x] = true;
		placedMines++;
	}
	console.log(field);

}

function make_onclick (coo_) {
	var coo = coo_;
	return function () {
		if (field[coo.y][coo.x]) {
			alert(field[coo.y][coo.x]);
			this.style.backgroundColor="red";
		} else {
			cascadeOpen(coo.x,coo.y);
		}
	}
}

function cascadeOpen(x,y) {
	if ((!(x<cols && x>=0 && y<rows && y>=0)) || (fieldElement.childNodes[x].childNodes[y].innerHTML != "X")) {
		return;
	}
	
	fieldElement.childNodes[x].childNodes[y].style.backgroundColor = "white";
	var check = function(x,y) {
		return (x<cols && x>=0 && y<rows && y>=0 && field[y][x]);
	}
	
	var counter = 0;
	
	if (check(x+1,y+1) ) counter++;
	if (check(x  ,y+1) ) counter++;
	if (check(x-1,y+1) ) counter++;
	if (check(x-1,y  ) ) counter++;
	if (check(x-1,y-1) ) counter++;
	if (check(x  ,y-1) ) counter++;
	if (check(x+1,y-1) ) counter++;
	if (check(x+1,y  ) ) counter++;
	
	fieldElement.childNodes[x].childNodes[y].innerHTML = counter;
	
	if (counter == 0) {
		cascadeOpen(x+1,y+1);
		cascadeOpen(x  ,y+1);
		cascadeOpen(x-1,y+1);
		cascadeOpen(x-1,y  );
		cascadeOpen(x-1,y-1);
		cascadeOpen(x  ,y-1);
		cascadeOpen(x+1,y-1);
		cascadeOpen(x+1,y  );
	}
	
	
}

window.onload=onLoad;