"use strict";(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[522],{3905:(e,t,o)=>{o.d(t,{Zo:()=>c,kt:()=>p});var n=o(7294);function i(e,t,o){return t in e?Object.defineProperty(e,t,{value:o,enumerable:!0,configurable:!0,writable:!0}):e[t]=o,e}function a(e,t){var o=Object.keys(e);if(Object.getOwnPropertySymbols){var n=Object.getOwnPropertySymbols(e);t&&(n=n.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),o.push.apply(o,n)}return o}function r(e){for(var t=1;t<arguments.length;t++){var o=null!=arguments[t]?arguments[t]:{};t%2?a(Object(o),!0).forEach((function(t){i(e,t,o[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(o)):a(Object(o)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(o,t))}))}return e}function s(e,t){if(null==e)return{};var o,n,i=function(e,t){if(null==e)return{};var o,n,i={},a=Object.keys(e);for(n=0;n<a.length;n++)o=a[n],t.indexOf(o)>=0||(i[o]=e[o]);return i}(e,t);if(Object.getOwnPropertySymbols){var a=Object.getOwnPropertySymbols(e);for(n=0;n<a.length;n++)o=a[n],t.indexOf(o)>=0||Object.prototype.propertyIsEnumerable.call(e,o)&&(i[o]=e[o])}return i}var l=n.createContext({}),d=function(e){var t=n.useContext(l),o=t;return e&&(o="function"==typeof e?e(t):r(r({},t),e)),o},c=function(e){var t=d(e.components);return n.createElement(l.Provider,{value:t},e.children)},u={inlineCode:"code",wrapper:function(e){var t=e.children;return n.createElement(n.Fragment,{},t)}},m=n.forwardRef((function(e,t){var o=e.components,i=e.mdxType,a=e.originalType,l=e.parentName,c=s(e,["components","mdxType","originalType","parentName"]),m=d(o),p=i,h=m["".concat(l,".").concat(p)]||m[p]||u[p]||a;return o?n.createElement(h,r(r({ref:t},c),{},{components:o})):n.createElement(h,r({ref:t},c))}));function p(e,t){var o=arguments,i=t&&t.mdxType;if("string"==typeof e||i){var a=o.length,r=new Array(a);r[0]=m;var s={};for(var l in t)hasOwnProperty.call(t,l)&&(s[l]=t[l]);s.originalType=e,s.mdxType="string"==typeof e?e:i,r[1]=s;for(var d=2;d<a;d++)r[d]=o[d];return n.createElement.apply(null,r)}return n.createElement.apply(null,o)}m.displayName="MDXCreateElement"},1396:(e,t,o)=>{o.r(t),o.d(t,{assets:()=>w,contentTitle:()=>b,default:()=>I,frontMatter:()=>v,metadata:()=>C,toc:()=>x});var n=o(7462),i=o(7294),a=o(3905),r=o(4996),s=o(6010);const l={container:"container_ek75",cursorLocked:"cursorLocked_H61i",normal:"normal_n5ah",hoverable:"hoverable_F5EM",selected:"selected_mneN",locked:"locked_H8Qp",sprite:"sprite_ZRUo",tooltip:"tooltip_QxcU",count:"count_Z8Fk"};function d(e){let{sprite:t,tooltip:o,tooltipColor:n,count:a,countColor:r,hoverable:d,cantClick:c,type:u="normal",onClick:m}=e;return i.createElement("div",{onClick:m,className:(0,s.Z)(l.container,c&&l.cursorLocked,u&&l[u],d&&l.hoverable)},t&&i.createElement("img",{key:"sprite",className:l.sprite,src:t}),o&&i.createElement("span",{key:"tooltip",className:l.tooltip,style:{color:n||"#FFED00"}},o),a&&i.createElement("span",{key:"count",className:l.count,style:{color:r||"#FFFFFF"}},a))}const c="container_pBCk",u="title_NJ2n",m="description_dLcZ",p="slot_y50m",h="costs_eDr0",y="extra_ezSA",g="audio_UhcF";function k(e){let{title:t,description:o,slot:n,unlockCost:a,CCPV:r,extra:s,audio:l}=e;return i.createElement("div",{className:c},i.createElement("div",{className:u},t),i.createElement("div",{className:m},o),i.createElement("div",{className:p},n),i.createElement("div",{className:h},i.createElement("b",null,"Unlock Cost: "),a,i.createElement("br",null),i.createElement("b",null,"CCPV: "),r),s&&i.createElement("div",{className:y},s),l&&i.createElement("div",{className:g},l))}function f(e){let{columns:t,children:o}=e;return i.createElement("div",{style:{display:"grid",gridTemplateColumns:"auto ".repeat(null!=t?t:1).trimEnd()}},o)}const v={},b="SMaD items",C={unversionedId:"Modules/SMaD/items",id:"Modules/SMaD/items",title:"SMaD items",description:"This is a kind of wikipedia, information about items in SMaD module is collected here.",source:"@site/docs/Modules/SMaD/items.mdx",sourceDirName:"Modules/SMaD",slug:"/Modules/SMaD/items",permalink:"/TBB/docs/Modules/SMaD/items",draft:!1,editUrl:"https://github.com/zTBBz/TBB/edit/master/website/docs/Modules/SMaD/items.mdx",tags:[],version:"current",frontMatter:{},sidebar:"tutorialSidebar",next:{title:"Update 1.1.0 - 1.1.1",permalink:"/TBB/docs/Updates/1.1.0 - 1.1.1"}},w={},x=[],T={toc:x};function I(e){let{components:t,...o}=e;return(0,a.kt)("wrapper",(0,n.Z)({},T,o,{components:t,mdxType:"MDXLayout"}),(0,a.kt)("h1",{id:"smad-items"},"SMaD items"),(0,a.kt)("div",{className:"admonition admonition-tip alert alert--success"},(0,a.kt)("div",{parentName:"div",className:"admonition-heading"},(0,a.kt)("h5",{parentName:"div"},(0,a.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,a.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"12",height:"16",viewBox:"0 0 12 16"},(0,a.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.5 0C3.48 0 1 2.19 1 5c0 .92.55 2.25 1 3 1.34 2.25 1.78 2.78 2 4v1h5v-1c.22-1.22.66-1.75 2-4 .45-.75 1-2.08 1-3 0-2.81-2.48-5-5.5-5zm3.64 7.48c-.25.44-.47.8-.67 1.11-.86 1.41-1.25 2.06-1.45 3.23-.02.05-.02.11-.02.17H5c0-.06 0-.13-.02-.17-.2-1.17-.59-1.83-1.45-3.23-.2-.31-.42-.67-.67-1.11C2.44 6.78 2 5.65 2 5c0-2.2 2.02-4 4.5-4 1.22 0 2.36.42 3.22 1.19C10.55 2.94 11 3.94 11 5c0 .66-.44 1.78-.86 2.48zM4 14h5c-.23 1.14-1.3 2-2.5 2s-2.27-.86-2.5-2z"}))),"SMaD wikipedia")),(0,a.kt)("div",{parentName:"div",className:"admonition-content"},(0,a.kt)("p",{parentName:"div"},"This is a kind of wikipedia, information about items in SMaD module is collected here."))),(0,a.kt)(f,{columns:2,mdxType:"ItemFrames"},(0,a.kt)(k,{title:"Blood Donut",description:"Doughnuts themselves are very nutritious, but only energetically, now imagine that there is a doughnut that will be nutritious for your blood, replenishing the number of red blood cells in it, but this all takes time and it is better not to move during the replenishment of red blood cells.",slot:(0,a.kt)(d,{sprite:(0,r.Z)("/img/mod/Blood_Donut.png"),hoverable:!0,count:1,tooltip:"$45",mdxType:"InventorySlot"}),unlockCost:0,CCPV:5,extra:(0,a.kt)("i",null,"Paralize you and heal HP +1 in second for 60 seconds."),audio:(0,a.kt)("audio",{controls:!0,src:(0,r.Z)("/media/Blood_Donut_Use.ogg")}),mdxType:"ItemFrame"}),(0,a.kt)(k,{title:"Blind Mushroom",description:"Everyone's favorite mushroom from the game SUPER-CREPE. Feel yourself Super-Crepe!",slot:(0,a.kt)(d,{sprite:(0,r.Z)("/img/mod/Blind_Mushroom.png"),hoverable:!0,count:1,tooltip:"$35",mdxType:"InventorySlot"}),unlockCost:0,CCPV:5,extra:(0,a.kt)("i",null,"Heal 15 HP and you get Invincible for 25 seconds."),audio:(0,a.kt)("audio",{controls:!0,src:(0,r.Z)("/media/Blind_Mushroom_Use.ogg")}),mdxType:"ItemFrame"}),(0,a.kt)(k,{title:"BOOMcorn",description:"This item was still in the Hitman beta, but for their game it is too refined a way to kill. If you wanted to become a kamikaze, here's your chance.  As you can understand, this is not popcorn, but just a bomb in a XXL popcorn bag.",slot:(0,a.kt)(d,{sprite:(0,r.Z)("/img/mod/Boomkorn.png"),hoverable:!0,count:1,tooltip:"$35",mdxType:"InventorySlot"}),unlockCost:0,CCPV:3,extra:(0,a.kt)("i",null,"Spawn Normal explosion."),audio:"No custom audio",mdxType:"ItemFrame"}),(0,a.kt)(k,{title:"Conditioner Icecream",description:"Is someone tired of their ice cream constantly melting? Well, now it will freeze together with the ice cream, because the ice cream has a built-in air conditioner! Yes, you heard right!",slot:(0,a.kt)(d,{sprite:(0,r.Z)("/img/mod/Vent_IceCream.png"),hoverable:!0,count:1,tooltip:"$30",mdxType:"InventorySlot"}),unlockCost:0,CCPV:5,extra:(0,a.kt)("i",null,"Heal 20 HP and frozen you for 10 seconds."),audio:(0,a.kt)("audio",{controls:!0,src:(0,r.Z)("/media/Vent_IceCream_Use.ogg")}),mdxType:"ItemFrame"}),(0,a.kt)(k,{title:"Steel Apple",description:"The latest development of Mech.Food.Industrial and yes.. this apple... steel apple.. The essence is simple when eaten, it envelops the organs and skin with a special alloy that can delay bullets and reduce damage from them. However, it big damages the body from the inside..It is usefull, isn't it?",slot:(0,a.kt)(d,{sprite:(0,r.Z)("/img/mod/Steel_Apple.png"),hoverable:!0,count:1,tooltip:"$60",mdxType:"InventorySlot"}),unlockCost:0,CCPV:8,extra:(0,a.kt)("i",null,"Damage you for 75 HP and you get reduce of damage by 2 times, resistance to bullets and fire, but you get very loud, infinity playing Steel_Apple_Walk.ogg."),audio:(0,a.kt)("div",null,(0,a.kt)("audio",{controls:!0,src:(0,r.Z)("/media/Steel_Apple_Use.ogg")}),(0,a.kt)("audio",{controls:!0,src:(0,r.Z)("/media/Steel_Apple_Walk.ogg")})),mdxType:"ItemFrame"}),(0,a.kt)(k,{title:"Tentacle of the Kraken",description:"Any Chinese would give a fortune for such a tentacle! What is unique about it? It has strong healing properties, heals all wounds, but gives you a taste of seasickness. Bon Appetit!",slot:(0,a.kt)(d,{sprite:(0,r.Z)("/img/mod/Tentacle_Kraken.png"),hoverable:!0,count:1,tooltip:"$95",mdxType:"InventorySlot"}),unlockCost:0,CCPV:5,extra:(0,a.kt)("i",null,"Heal 180 HP and for 25 seconds damage you and debuff speed stat -3."),audio:"No custom audio",mdxType:"ItemFrame"}),(0,a.kt)(k,{title:"Brain Jellyfish",description:"A fairly decent-sized jellyfish that can control the host's brain, transmitting its properties to the host's body, even if not for long.",slot:(0,a.kt)(d,{sprite:(0,r.Z)("/img/mod/Brain_Jellyfish.png"),hoverable:!0,count:1,tooltip:"$40",mdxType:"InventorySlot"}),unlockCost:0,CCPV:4,extra:(0,a.kt)("i",null,"Get you Enraged and Electrotouch for 25 seconds."),audio:(0,a.kt)("audio",{controls:!0,src:(0,r.Z)("/media/Brain_Jellyfish_Use.ogg")}),mdxType:"ItemFrame"}),(0,a.kt)(k,{title:"Botex Leg",description:"Chicken leg straight from one of the most famous fast food restaurants with a secret ingredient. Oversaturating the body.",slot:(0,a.kt)(d,{sprite:(0,r.Z)("/img/mod/BotexChicken.png"),hoverable:!0,count:1,tooltip:"$60",mdxType:"InventorySlot"}),unlockCost:0,CCPV:6,extra:(0,a.kt)("i",null,"Heal 35 HP, decrease your speed -3 and you get Giant."),audio:(0,a.kt)("audio",{controls:!0,src:(0,r.Z)("/media/BotexLeg_Use.ogg")}),mdxType:"ItemFrame"}),(0,a.kt)(k,{title:"Boompkin",description:"Is it just me, or is there something wrong with this pumpkin?",slot:(0,a.kt)(d,{sprite:(0,r.Z)("/img/mod/Boom_Pumpkin.png"),hoverable:!0,count:1,tooltip:"$35",mdxType:"InventorySlot"}),unlockCost:0,CCPV:3,extra:(0,a.kt)("i",null,"Spawn normal explosion."),audio:"No custom audio",mdxType:"ItemFrame"}),(0,a.kt)(k,{title:"Fire Salamander Heart",description:"The Salamander heart is an incredibly nasty-tasting organ that pumps blood. I do not think that you need to eat it, although if you are a Pyromancer, it is your best friend, because your blood is saturated with special cells and will spread them throughout the body and you will become less vulnerable to fire. These cells are able to adapt quickly, it is a pity that your body will not accept them immediately.. so that.. Good luck surviving the War inside your body!",slot:(0,a.kt)(d,{sprite:(0,r.Z)("/img/mod/Salamandr_Heart.png"),hoverable:!0,count:1,tooltip:"$60",mdxType:"InventorySlot"}),unlockCost:0,CCPV:6,extra:(0,a.kt)("i",null,"Damage you for 80 HP, give you endless Resist Fire."),audio:(0,a.kt)("audio",{controls:!0,src:(0,r.Z)("/media/Fire_Salamander_Heart_Use.ogg")}),mdxType:"ItemFrame"}),(0,a.kt)(k,{title:"Fish from Well",description:"The legendary fish that was caught from the very Well. it's all dry, but so warm.. Is it edible? Is unknown.. no one has tried it, but you can be the first! But according to the legends, it gives a surge of strength, heals all wounds and gives a sense of good luck.",slot:(0,a.kt)(d,{sprite:(0,r.Z)("/img/mod/Luck_Fish.png"),hoverable:!0,count:1,tooltip:"$60",mdxType:"InventorySlot"}),unlockCost:0,CCPV:10,extra:(0,a.kt)("i",null,"After use with 45/15/1% give 20/50/1000 Money."),audio:(0,a.kt)("audio",{controls:!0,src:(0,r.Z)("/media/FishOfLuck_Use.ogg")}),mdxType:"ItemFrame"}),(0,a.kt)(k,{title:"Tear of Heaven",description:"Heaven's tears are granted if the gods like your soul. A person who receives the Tears of Heaven at a critical moment can drink them to get even temporary, but the power of God, and restore the body, but his body is not able to withstand the power of the gods,which is why it is not able to move.",slot:(0,a.kt)(d,{sprite:(0,r.Z)("/img/mod/Heaven_Tears.png"),hoverable:!0,count:1,tooltip:"$45",mdxType:"InventorySlot"}),unlockCost:0,CCPV:10,extra:(0,a.kt)("i",null,"Heal 99999 HP, give Invincible for 30 seconds."),audio:(0,a.kt)("audio",{controls:!0,src:(0,r.Z)("/media/Tears_Heaven_Use.ogg")}),mdxType:"ItemFrame"}),(0,a.kt)(k,{title:"Fish Oil",description:"Fish oil - as scientists have proven a very useful thing, although people are not completely sure about it. its taste and color are known to many,but few people know that it can restore the cells of human organs, as well as increase your strength, but it is quite a heavy product so that a run is not fatal for you..but still it is not desirable to run. But you did not listen to your mother and did not eat fish oil as a child, even in the game eat.",slot:(0,a.kt)(d,{sprite:(0,r.Z)("/img/mod/Fish_Fat.png"),hoverable:!0,count:2,tooltip:"$35",mdxType:"InventorySlot"}),unlockCost:0,CCPV:6,extra:(0,a.kt)("i",null,"Heal 10 HP, increase strength +2 and decrease speed -2 for 15 seconds."),audio:"No custom audio",mdxType:"ItemFrame"}),(0,a.kt)(k,{title:"Divine Honey",description:"This honey was produced by the legendary divine bees, or so the legends say. This honey was obtained in the most insidious way - Stolen. It has effective regenerative abilities, rejuvenates the skin and regenerates lost cells, but it all takes time. Because of the rush during the Assembly of honey, larvae gather in it.",slot:(0,a.kt)(d,{sprite:(0,r.Z)("/img/mod/Honey.png"),hoverable:!0,count:1,tooltip:"$55",mdxType:"InventorySlot"}),unlockCost:0,CCPV:8,extra:(0,a.kt)("i",null,"Heal some HP for 30 seconds, make your speed to 0."),audio:(0,a.kt)("audio",{controls:!0,src:(0,r.Z)("/media/Divine_Honey_Use.ogg")}),mdxType:"ItemFrame"}),(0,a.kt)(k,{title:"Juicy Watermelon",description:"Mmmmmmm.. how juicy and delicious this watermelon is..watermelon juice is flowing out of it.. or is it not juice? I won't torment you. It restores 80 HP to Vampires when people are only 30.. keep in mind that vampires are good, people are bad, I'm talking about bloodmixing.",slot:(0,a.kt)(d,{sprite:(0,r.Z)("/img/mod/Blood_Watermelon.png"),hoverable:!0,count:1,tooltip:"$35",mdxType:"InventorySlot"}),unlockCost:0,CCPV:4,extra:(0,a.kt)("i",null,"Heal 80 HP if you have BloodRestoresHealth trait, else heal 30 HP and confused you for 25 seconds."),audio:"No custom audio",mdxType:"ItemFrame"}),(0,a.kt)(k,{title:"Suspicious cake",description:"Is it just me, or does this cake look a little suspicious? In any case, you eat it.",slot:(0,a.kt)(d,{sprite:(0,r.Z)("/img/mod/Evil_Cake.png"),hoverable:!0,count:1,tooltip:"$25",mdxType:"InventorySlot"}),unlockCost:0,CCPV:8,extra:(0,a.kt)("i",null,"Turns you into something after torment..."),audio:(0,a.kt)("audio",{controls:!0,src:(0,r.Z)("/media/Evil_Cake_Use.ogg")}),mdxType:"ItemFrame"})))}I.isMDXComponent=!0}}]);