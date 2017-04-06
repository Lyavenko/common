var NDrops = 100;
var drops = [];
var desiredFPS = 60;

function Drop() {
	this.move = function() {
		this.top+=100.0/this.depth/desiredFPS;
		this.phase+=2.0/desiredFPS;
		if (this.top>110) {
			this.top = -10;
			this.left = Math.random() * 100;

		}
		
		this.element.style.transform = "scaleX("+Math.sin(this.phase)+")";

		
		this.element.style.left = this.left+'%';
		this.element.style.top = this.top+'%';
	}
	
	this.top = Math.random() * 120-10;
	this.left = Math.random() * 100;
	this.depth = Math.random() * 10+2;
	this.phase = Math.random()*6.28;

	this.element = document.createElement("img");
	this.element.setAttribute("src","drop.jpg");
	this.element.style.position = "absolute";
	this.element.style.zIndex = 20-this.depth;
	this.element.style.width = (20/this.depth)+"%";
	this.element.style.height = (35/this.depth)+"%";
	document.getElementById("drops").appendChild(this.element);
}

function onLoad() {
	for (var i=1;i<NDrops;i++) {
		drops[i] = new Drop();
		
	}
	setInterval(function() {
		for (var i=1;i<NDrops;i++) {
			drops[i].move();
		}
	},1000/desiredFPS);
}


window.onload=onLoad;