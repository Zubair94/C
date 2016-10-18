#include <cstdio>
#include <cstdlib>
#include <iostream>
using namespace std;
typedef struct node
{
    int data;
    struct node *leftchild;
    struct node *rightchild;

}*tree;

tree root=NULL;


tree maketree(tree ptr,int x)
{
    if(ptr==NULL)
    {
        ptr= new node;
        ptr->data=x;
        ptr->leftchild=NULL;
        ptr->rightchild=NULL;
    }
    else if(x<ptr->data)
    {
        ptr->leftchild=maketree(ptr->leftchild,x);
    }
    else if(x>ptr->data)
    {
        ptr->rightchild=maketree(ptr->rightchild,x);
    }
    return ptr;
}


tree inorder(tree p)
{

    if(p!=NULL)
    {
        inorder(p->leftchild);
        cout<<p->data<<"--";
        inorder(p->rightchild);
    }
}

tree search_(tree p,int x)
{
    int flag=0;
    while(p!=NULL &&flag!=1)
    {
        if(p->data==x)
        {
            flag=1;
        }
        else if(x<p->data)
        {
            p=p->leftchild;


        }
        else if(x>p->data)
        {
            p=p->rightchild;

        }
    }
    if(flag==1)
    {
        cout<<"\nfound "<<x;
    }
    else
    {
        cout<<"\n"<<x<<" not found";
    }
}
tree preorder(tree p)
{
    if(p!=NULL)
    {
        cout<<p->data<<"--";
        preorder(p->leftchild);
        preorder(p->rightchild);
    }
}
tree postorder(tree p)
{
    if(p!=NULL)
    {
        postorder(p->leftchild);
        postorder(p->rightchild);
        cout<<p->data<<"--";
    }
}
int main()
{
    int ins,size_,find_;
    cout<<"Size:";
    cin>>size_;
    for(int i=0;i<size_;i++)
    {
        cout<<"\nInput Item:";
        cin>>ins;
       root = maketree(root,ins);
    }
    //root = maketree(root,9);
    cout<<"\ninorder:";
    inorder(root);
    cout<<"\npreorder:";
    preorder(root);
    cout<<"\npostorder:";
    postorder(root);
    cout<<"\n\nFind an item:";
    cin>>find_;
    search_(root,find_);
    return 0;
}
