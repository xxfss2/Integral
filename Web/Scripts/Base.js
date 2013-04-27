// JScript 文件

//-------------------------------带ＣＨＥＣＫＢＯＸ的ＧＲＩＤＶＩＥＷ用(可多选）
 var selList = new Array();

 function checkedItem(id,obj) {
     var cb = $(obj);
     if (cb.attr("checked") == true) {
         selList.push(id);
     }
     else {
         for (i = 0; i < selList.length; i++) {
             if (selList[i] == id) {
                 selList.splice(i, 1);
             }
         }
     }
 } 
//全选　全不选
 function checkAll(checkbox) {
     var ddl = $(checkbox);
        if(ddl.attr("checked")==true)
        {
         $("input[type='checkbox']:not(:checked)").click();
        //$("input[type='checkbox'][checked='']")
 
         }
        else {
         $('input[type="checkbox"]').attr("checked", false);
         selList.length = 0;
        }

 }


//--------------------------------------------------------------------------
//   $(function(){
//        $("#form1").append("<input id=\"HDids\" name =\"HDids\" type=\"hidden\" />");
//        $(".BTedit").bind("click",function(){
//          if(selList.length!=1)
//           {
//             alert('请选择一条要修改的数据！'); 
//             return false; 
//           }    
//          if(confirm('确认修改？')==true)
//          {
//            var ids=selList.join(';');
//            $("#HDids").val(ids);
//            alert(ids); 
//          }
//          else{return false;}});
//          $(".BTdel").bind("click",function(){
//            if(selList.length==0)
//           {
//                alert('请选择要删除的数据！'); 
//               return false; 
//          }  
//          if(confirm('确认删除？')==true)
//          {            var ids=selList.join(';');
//            $("#HDids").val(ids);
//            alert(ids); 
//          }
//          else{return false;} }); 
//      }); 
        