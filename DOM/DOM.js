
function onLoad() {
	var el = document.getElementById('wysiwyg'); 
	var str = parseElements(el);
	document.getElementById('struct').innerHTML = str;
}

function  parseElements(el) {
	var str = '';
	switch (el.nodeType) {
		case 1: // Element 
			str += '&lt;'+el.tagName + '&gt;<ul>';
			for( var i=0; i<el.childNodes.length; i++) {
				str+='<li>'+parseElements(el.childNodes[i])+ '</li>';
			}
			str+= '</ul>';
		break;
		
		case 3: // Text 
			str += '*TEXT*'+el.nodeValue+'';
		break;
	}
	return str;
}


window.onload=onLoad;