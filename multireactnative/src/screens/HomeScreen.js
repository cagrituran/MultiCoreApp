/* eslint-disable prettier/prettier */
/* eslint-disable semi */
/* eslint-disable prettier/prettier */
import React from 'react'
import {View,Text,Button} from 'react-native';

export default function HomeScreen({navigation}) {
    const {navigate} = navigation;
  return (
    <View style = {{flex:1,alignItems:'center',justifyContent:'center'}}>
        <View>
          <Text>HomeScreen</Text>
        </View>
        <View>
            <Button
             title="Go to Category Screen"
             onPress={()=>navigate('Category')}
            
            />
            <Button
             title="Go to Product Screen"
             onPress={()=>navigate('Product')}
            
            />
        </View>
    </View>
  )
}
