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

int search_(tree p,int x)
{
    int flag=0,insflag=0;
    while(p!=NULL &&flag!=1)
    {
        if(p->data==x)
        {
            flag=1;
            insflag==1;
            return insflag;

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
tree insert_(tree p,int x,int f)
{
  search_(p,x);
  if(f==1)
  {
      cout<<"\nNot possible to insert";
  }
  else
  {
      maketree(p,x);
  }

}

tree delete_(tree p,int x,int f)
{
    tree temp;
   search_(p,x);
   if(f==1)
    {

      if(x<p->data)
      {
          delete_(p->leftchild,x,f);
      }
      else if(x>p->data)
      {
          delete_(p->rightchild,x,f);
      }
      else if(p->leftchild!=NULL && p->rightchild!=NULL)
      {
          tree npt=NULL;
        p->data=npt->rightchild->data;
        delete_(p->rightchild,x,f);
      }

    }
    else
    {
      cout<<"not possible";
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
    int ins1,f;
    f=search_(root,find_);
    cout<<"\n\nNew item:";
    cin>>ins1;
    delete_(root,ins1,f);
    cout<<"\n";
    inorder(root);
    return 0;
}
