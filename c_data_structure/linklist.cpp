#include <cstdio>
#include <cstdlib>
#include <iostream>
using namespace std;
typedef struct node
{
    char data;
    struct node *next;

}*nodeptr;

nodeptr head=NULL,ptr=NULL;

void linked_list(int x)
{
    nodeptr npt=new node;
    npt->data=x;
    npt->next=NULL;
    if(head==NULL)
    {
        head=npt;
    }
    else
    {
        ptr->next=npt;
    }
    ptr=npt;
}

void print()
{
    nodeptr p=head;

   while(p!=NULL)
   {
       cout<<p->data<<"---->";
       p=p->next;
   }
}

void search_(nodeptr q,char x)
{
    int flag=0;

    while(q!=NULL && flag==0)
    {
        if(q->data==x)
        {
            flag=1;
        }
        q=q->next;

    }
    if(flag==1)
    {
        cout<<"\nfound "<<x;
    }
    else
    {
        cout<<"\nnot found";
    }

}
void linked_list_insert(char x,char y)
{
    nodeptr npt=new node;
    npt->data=x;
    nodeptr p=head;
    while(p->data!=y)
    {
        p=p->next;
    }
    npt->next=p->next;
    p->next=npt;

}

void linked_list_insert_before(char x,char y)
{
    nodeptr p=head;
    nodeptr npt=new node;
    npt->data=x;
    if(head->data==y)
    {
        npt->next=p;
        head=npt;
    }
    else
    {
    while(p->next->data!=y)
    {
        p=p->next;
    }
    npt->next=p->next;
    p->next=npt;
    }
}

void linked_list_delete(char x)
{
    nodeptr p=head;
    nodeptr del;
    if(head->data==x)
    {
        head=head->next;
    }
    else
    {
        while(p->data!=x)
        {
            del=p;
            p=p->next;
        }
        del->next=p->next;
    }
    delete (p);

}


int main()
{
    int t,size_;
    cout<<"Enter list Size=";
    cin>>size_;
    cout<<endl;
    char input,ans;
        for(int i=0;i<size_;i++)
        {
            cout<<"Enter value of list=";
            cin>>input;
            linked_list(input);
        }

    while(t--)
    {
    char choice;
    cout<<"\n\n\nEnter 2 to Search\nInput 3 to Insert After Data\nInput 4 Before Data\nInput 5 to Delete\nInput 6 to Print\nInput e to Exit";
    cout<<"\nchoice=";
    cin>>choice;
    switch(choice)
    {
        case '2':
            char find_;
            cout<<"\n\nEnter number to search:";
            cin>>find_;
            search_(head,find_);
            break;
        case '3':
            char ins,insafter;
            cout<<"\n\nInput data You want to insert=";
            cin>>ins;
            cout<<"\n\nInput After which data you want to insert=";
            cin>>insafter;
            linked_list_insert(ins,insafter);
            break;
        case '6':
            print();
            break;
        case '4':
            char insbefore;
            cout<<"\n\nInput data You want to insert=";
            cin>>ins;
            cout<<"\n\nInput Before which data you want to insert=";
            cin>>insbefore;
            linked_list_insert_before(ins,insbefore);
            break;
        case '5':
            char delete_;
            cout<<"\n\nInput data You want to delete=";
            cin>>delete_;
            linked_list_delete(delete_);
            break;
        case 'e':
            return 0;
        default:
            cout<<"\nInvalid";
    }
    }
    return 0;
}
