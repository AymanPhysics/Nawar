   M S B A M L   `   `   `  ???? 	  OMEGA&     WpfApplication1.SupliersPayments   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .???    Bg#???   .+?? $??13,19,14,10q?????   ?? EndPoint$  0.5,1&? ?? 
StartPoint$ 0.5,0&?.???  ? Color$ White?? ? Offset$ 0Q?? $ 	#FF6DD9FF??$ 1Q?.+??? -    ??Name$ ToName?? ?? AutoWordSelection . $??28????.  $??
203,42,0,0q? ?? 	MaxLength$	 100??$??1??$	??220??$	??Top=?$
??Left=?.?????? $  0.5,1&?$ 0.5,0&?.??? $ White??$ 0Q?? $ 	#37FFFF00??$ 1Q?.???? -    ??Name$ 	lblItemId?????	#FF078200$??1q?$??المورد?????	#FF078200$??28??$??Center=?$??	13,42,0,0q? ? UseLayoutRounding . $	??120??$	??Top=?$
??Left=??? -   $
 ToId?? . $??28??$??
139,42,0,0q?$ 10??$
??3333??$??60??$	??Top=?$
??Left=???.  .?????? $  0.5,1&?$ 0.5,0&?.??? $ White??$ 0Q?? $ 	#37FFFF00??$ 1Q?.???? -   $ lblFromDate?????	#FF078200$??1q?$??	From date?????	#FF078200$??28??$??Center=?$??13,9,0,0q? . $	??120??$	??Top=?$
??Left=?(  "System.Windows.Controls.DatePicker  -   	  Name$	 FromDate??
   FirstDayOfWeek$
 Saturday=?$??28??$??	138,9,0,0q?$??3??$	??129??$	??Top=?$
??Left=???. ?? -   $ 	lblToDate?????	#FF078200$??1q?$??To Date?????	#FF078200$??28??$??Center=?$??	275,9,0,0q? . $	??120??$	??Top=?$
??Left=?  -   $	 ToDate??$
 Saturday=?$??28??$??	401,9,0,0q?$??4??$	??129??$	??Top=?$
??Left=???. &   System.Windows.Controls.DataGrid  -     Name$ G1??$??10,75,240,273q?   AlternatingRowBackground ?	#37000000   RowBackground ?	#FFFFFFAF   CanUserReorderColumns .     CanUserAddRows .     CanUserDeleteRows .     MinColumnWidth$ 60Q?   HeadersVisibility$ Column=?$??Stretch=?   CanUserSortColumns .  J? Effect 3  -System.Windows.Media.Effects.DropShadowEffect  7  1System.Windows.Forms.Integration.WindowsFormsHost  -	     Name$	 WFH??$??	10,0,0,51q?   TabIndex$	 333??$	??217??$??Bottom=?$
??Left=?$	??762??   
Background Z?   -
   $ G3??$??777,0,10,51q? ?	#37000000 ?	#FFFFFFAF .   .   .  $ 60Q?$ Column=?$??Stretch=? . $	??217??$??Bottom=?   ?? -    ??Name$ btnSave??$??حفظ??$
??Left=?$??63,0,0,8q?$	??101??$??Bottom=?$	??136?? 
 BgSave#???  $??38????.  ?? -   $ lblItemId_Copy?????	#FF078200$??1q?$??قيمة العقد?????	#FF078200$??28??$??Center=?$??	255,0,0,8q? . $	??120??$??Bottom=?$
??Left=??? -   $ Total?? . $??28??$??	381,0,0,8q?$ 10??$??3??$	??120??$??Bottom=?$
??Left=?{?.  .?????? $  0.5,1&?$ 0.5,0&?.??? $ White??$ 0Q?? $ 	#37FFFF00??$ 1Q?.???? -   $ lblItemId_Copy1?????	#FF078200$??1q?$??المدفوع?????	#FF078200$??28??$??Center=?$??	506,0,0,8q? . $	??120??$??Bottom=?$
??Left=??? -   $
 Paid?? . $??28??$??	632,0,0,8q?$ 10??$??3??$	??150??$??Bottom=?$
??Left=?{?.  .?????? $  0.5,1&?$ 0.5,0&?.??? $ White??$ 0Q?? $ 	#37FFFF00??$ 1Q?.???? -   $ lblItemId_Copy2?????	#FF078200$??1q?$??المتبقي?????	#FF078200$??28??$??Center=?$??	787,0,0,8q? . $	??120??$??Bottom=?$
??Left=??? -   $ 	Remaining?? . $??28??$??	913,0,0,8q?$ 10??$??3??$	??157??$??Bottom=?$
??Left=?{?.  .?????? $  0.5,1&?$ 0.5,0&?.??? $ White??$ 0Q?? $ 	#37FFFF00??$ 1Q?.???? -   $ lblItemId_Copy3?????	#FF078200$??1q?$??المبلغ?????	#FF078200$??28??$??Center=?$??
0,75,115,0q? . $	??120??$	??Top=?$??Right=??? -   $ Total0?? . $??28??$??	0,75,10,0q?$ 10??$??3??$??99??$	??Top=?$??Right=?{?.  .?????? $  0.5,1&?$ 0.5,0&?.??? $ White??$ 0Q?? $ 	#37FFFF00??$ 1Q?.???? -   $ lblItemId_Copy4?????	#FF078200$??1q?$??المدفوع?????	#FF078200$??28??$??Center=?$??0,108,115,0q? . $	??120??$	??Top=?$??Right=??? -   $ Paid0?? . $??28??$??
0,108,10,0q?$ 10??$??3??$??99??$	??Top=?$??Right=?{?.  .?????? $  0.5,1&?$ 0.5,0&?.??? $ White??$ 0Q?? $ 	#37FFFF00??$ 1Q?.???? -   $ lblItemId_Copy5?????	#FF078200$??1q?$??المتبقي?????	#FF078200$??28??$??Center=?$??0,141,115,0q? . $	??120??$	??Top=?$??Right=??? -   $ 
Remaining0?? . $??28??$??
0,141,10,0q?$ 10??$??3??$??99??$	??Top=?$??Right=?{?.  .?????? $  0.5,1&?$ 0.5,0&?.??? $ White??$ 0Q?? $ 	#37FFFF00??$ 1Q?.??