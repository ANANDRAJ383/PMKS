var slidespeed=1500
//specify images
var slideimages=new Array("Header/Static/flash/header.jpg","Header/Static/flash/header1.jpg","Header/Static/flash/header2.jpg","Header/Static/flash/header3.jpg","Header/Static/flash/header4.jpg","Header/Static/flash/header5.jpg")
//specify corresponding links
var newwindow=0 //open links in new window? 1=yes, 0=no
var imageholder=new Array()
var ie=document.all
for (i=0;i<slideimages.length;i++){
imageholder[i]=new Image()
imageholder[i].src=slideimages[i]
}
function gotoshow(){
if (newwindow)
window.open(slidelinks[whichlink])
else
window.location=slidelinks[whichlink]
}
