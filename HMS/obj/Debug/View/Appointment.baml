   M S B A M L   `   `   `  ����>  :HMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:HMS.ViewModelHMS.ViewModel  5   	       HMS.View.Appointment   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   1	ViewModelclr-namespace:HMS.ViewModel     5   	   -   5          � Title$  
Assistant2��5   	   $	��300��6   $	��700��6)   .��5      �� 
�������.+�5   
   �� -   5         ��Name$ lblPatientID��5      $��25��6&   $��70��62    �� Left$ 0��6=   
 �� Top$ 10��6M   $��
Patient ID��6]   �� 5	   
   -   5         ��Name$ txtboxPatientID��5	      $��P1��6+   $��25��65   $	��100��6A   $ 75��6M   $ 10��6^   6n   �� 5
   
   -   5         ��Name$ 	btnSearch��5
      $��Search��6$   $��25��65   $��50��6A   $ 10��6L   $	 200��6\   6n   �� 5   
   -   5        $ btnAdd��5      $	��Add��6!   $��25��6/   $��50��6;   $ 10��6F   $	 260��6V   6h   �� 5   
   -   5        $��
canvasList��5      $	��200��6$   $	��660��61   $ 50��6=   $ 10��6M   .+�5      �� -   5        $��PatientList��5      $	��200��6*   $	��660��67   $ 0��6�   ��6C   �� *	GetList+ �� View 5      �� 5      .P�5      �� $��ID��6)    �� Width$ 90��65    �� DisplayMemberBinding 6@   �� *	PatientID+�� 5      $
��Name��6)   $ 90��67    6B   �� *PatientName+�� 5      $��Address��6)   $ 90��6:    6E   �� *PatientAddress+�� 5      $��Contact��6)   $ 90��6:    6E   �� *PatientContact+�� 5      $��	Doctor ID��6)   $ 90��6<    6G   �� *
DoctorName+�� 5      $
��Date��6)   $ 90��67    6B   �� *Date+�� 5      $
��Time��6)   $ 90��67    6B   �� *Time+5      5      5      5      5      