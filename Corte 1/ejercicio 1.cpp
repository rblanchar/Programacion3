#include <iostream>

using namespace std;

int main(){

	int estrato,kilowats,op;
	float iva,total,subtotal;
	double to1=0,to2=0,to3=0,to4=0,to5=0,totalfac;
	char opci;
	opci='s';
	
	while(opci=='s'){
	
		cout<<"\n Escoja la opcion del estrato al que desea consultar:"
			<<"\n (1).........son los estratos 0 y 1 "
			<<"\n (2).........son los estratos 2 "
			<<"\n (3).........son los estratos 3 "
			<<"\n (4).........son los estratos 4 "
			<<"\n (5).........son los estratos 5 en adelante "<<endl;
		cin>>op;
		switch(op)
		{
    		case 1 : cout<<" Usted consulta los estratos 0 y 1, con un valor de 180 pesos por kilovatio"<<endl;
    				 cout<<"=============================================================================="<<endl;
    				 cout<<"Digite el estrato del usuario: ";
    				 cin>>estrato;
					 cout<<"\n Digite el consumo de kilovatios del usuario: ";
					 cin>>kilowats;
					 
					 subtotal=kilowats*180;
					 iva=subtotal*16/100;
					 total=subtotal+iva;
					to1=to1+total;
					 cout<<"\n====================================="
					 	 <<"\n             FACTURACION"	  	
					 	 <<"\n====================================="	  	
					 	 <<"\n estrato: "<<estrato
						 <<"\n kilovateos consumidos: "<<kilowats	  	
					 	 <<"\n subtotal: "<<subtotal	  	
					 	 <<"\n iva: "<<iva	  	
					 	 <<"\n====================================="	  	
					 	 <<"\n total a pagar :"<<total
						 <<"\n====================================="<<endl;	  	
    		break;
    		case 2 :cout<<" Usted consulta los estratos 2, con un valor de 220 pesos por kilovatio"<<endl;
    				 cout<<"=============================================================================="<<endl;
    				 cout<<"Digite el estrato del usuario: ";
    				 cin>>estrato;
					 cout<<"\n Digite el consumo de kilovatios del usuario: ";
					 cin>>kilowats;
					 
					 subtotal=kilowats*220;
					 iva=subtotal*16/100;
					 total=subtotal+iva;
					to2=to2+total;
					 cout<<"\n====================================="
					 	 <<"\n             FACTURACION"	  	
					 	 <<"\n====================================="	  	
					 	 <<"\n estrato: "<<estrato
						 <<"\n kilovateos consumidos: "<<kilowats	  	
					 	 <<"\n subtotal: "<<subtotal	  	
					 	 <<"\n iva: "<<iva	  	
					 	 <<"\n====================================="	  	
					 	 <<"\n total a pagar :"<<total
						 <<"\n====================================="<<endl; 
    		break;
    		case 3 :cout<<" Usted consulta los estratos 3, con un valor de 280 pesos por kilovatio"<<endl;
    				 cout<<"=============================================================================="<<endl;
    				 cout<<"Digite el estrato del usuario: ";
    				 cin>>estrato;
					 cout<<"\n Digite el consumo de kilovatios del usuario: ";
					 cin>>kilowats;
					 
					 subtotal=kilowats*280;
					 iva=subtotal*16/100;
					 total=subtotal+iva;
					to3=to3+total;
					 cout<<"\n====================================="
					 	 <<"\n             FACTURACION"	  	
					 	 <<"\n====================================="	  	
					 	 <<"\n estrato: "<<estrato
						 <<"\n kilovateos consumidos: "<<kilowats	  	
					 	 <<"\n subtotal: "<<subtotal	  	
					 	 <<"\n iva: "<<iva	  	
					 	 <<"\n====================================="	  	
					 	 <<"\n total a pagar :"<<total
						 <<"\n====================================="<<endl; 
    		break;
    		case 4 :cout<<" Usted consulta los estratos 4, con un valor de 350 pesos por kilovatio"<<endl;
    				 cout<<"=============================================================================="<<endl;
    				 cout<<"Digite el estrato del usuario: ";
    				 cin>>estrato;
					 cout<<"\n Digite el consumo de kilovatios del usuario: ";
					 cin>>kilowats;
					 
					 subtotal=kilowats*350;
					 iva=subtotal*16/100;
					 total=subtotal+iva;
					to4=to4+total;
					 cout<<"\n====================================="
					 	 <<"\n             FACTURACION"	  	
					 	 <<"\n====================================="	  	
					 	 <<"\n estrato: "<<estrato
						 <<"\n kilovateos consumidos: "<<kilowats	  	
					 	 <<"\n subtotal: "<<subtotal	  	
					 	 <<"\n iva: "<<iva	  	
					 	 <<"\n====================================="	  	
					 	 <<"\n total a pagar :"<<total
						 <<"\n====================================="<<endl;
    		break;
			case 5 :cout<<" Usted consulta los estratos 5 en adelante, con un valor de 450 pesos por kilovatio"<<endl;
    				 cout<<"=============================================================================="<<endl;
    				 cout<<"Digite el estrato del usuario: ";
    				 cin>>estrato;
					 cout<<"\n Digite el consumo de kilovatios del usuario: ";
					 cin>>kilowats;
					 
					 subtotal=kilowats*180;
					 iva=subtotal*16/100;
					 total=subtotal+iva;
					to5=to5+total;
					 cout<<"\n====================================="
					 	 <<"\n             FACTURACION"	  	
					 	 <<"\n====================================="	  	
					 	 <<"\n estrato: "<<estrato
						 <<"\n kilovateos consumidos: "<<kilowats	  	
					 	 <<"\n subtotal: "<<subtotal	  	
					 	 <<"\n iva: "<<iva	  	
					 	 <<"\n====================================="	  	
					 	 <<"\n total a pagar :"<<total
						 <<"\n====================================="<<endl;
			break;	
    		default : cout << "Usted ha ingresado una opcion no correspondiente a las anteriores"<<endl;
		}
		cout<<"Desea consultar el valor de factura de otro estrato? s:si n:no"<<endl;
		cin>>opci;
	}
	
	totalfac=to1+to2+to3+to4+to5;
	cout<<"el total fracturado por la empresa es de: ";
	cin>>totalfac;
	cout<<"\n estudiante kevin parra";
	return 0;
}
