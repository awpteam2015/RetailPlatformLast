﻿// ==================================================================================================================                                                                                          
//        ,::i                                                           BBB                
//       BBBBBi                                                         EBBB                
//      MBBNBBU                                                         BBB,                
//     BBB. BBB     BBB,BBBBM   BBB   UBBB   MBB,  LBBBBBO,   :BBG,BBB :BBB  .BBBU  kBBBBBF 
//    BBB,  BBB    7BBBBS2BBBO  BBB  iBBBB  YBBJ :BBBMYNBBB:  FBBBBBB: OBB: 5BBB,  BBBi ,M, 
//   MBBY   BBB.   8BBB   :BBB  BBB .BBUBB  BB1  BBBi   kBBB  BBBM     BBBjBBBr    BBB1     
//  BBBBBBBBBBBu   BBB    FBBP  MBM BB. BB BBM  7BBB    MBBY .BBB     7BBGkBB1      JBBBBi  
// PBBBFE0GkBBBB  7BBX   uBBB   MBBMBu .BBOBB   rBBB   kBBB  ZBBq     BBB: BBBJ   .   iBBB  
//BBBB      iBBB  BBBBBBBBBE    EBBBB  ,BBBB     MBBBBBBBM   BBB,    iBBB  .BBB2 :BBBBBBB7  
//vr7        777  BBBu8O5:      .77r    Lr7       .7EZk;     L77     .Y7r   irLY  JNMMF:    
//               LBBj
//
// Apworks Application Development Framework
// Copyright (C) 2010-2015 by daxnet.
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ==================================================================================================================

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using CommonFrameWork.Domain.Entities;
using CommonFrameWork.Specifications;

namespace CommonFrameWork.Domain.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TAggregateRoot"></typeparam>
    public interface IRepository<TKey, TAggregateRoot>
        where TAggregateRoot : class, IAggregateRoot<TKey>
    {

        void Add(TAggregateRoot aggregateRoot);

        void Remove(TAggregateRoot aggregateRoot);

        void Update(TAggregateRoot aggregateRoot);

        bool Exists(Expression<Func<TAggregateRoot, bool>> wherePredicate);

        TAggregateRoot GetByKey(TKey key);

        IQueryable<TAggregateRoot> FindAll();

        IQueryable<TAggregateRoot> FindAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, OrderBy sortOrder);

        PagedResult<TAggregateRoot> FindAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, OrderBy sortOrder, int pageNumber, int pageSize);

        IQueryable<TAggregateRoot> FindAll(Expression<Func<TAggregateRoot, bool>> wherePredicate);

        IQueryable<TAggregateRoot> FindAll(Expression<Func<TAggregateRoot, bool>> wherePredicate, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, OrderBy sortOrder);

        PagedResult<TAggregateRoot> FindAll(Expression<Func<TAggregateRoot, bool>> wherePredicate, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, OrderBy sortOrder, int pageNumber, int pageSize);
        IQueryable<TAggregateRoot> FindAllAndFetch(Expression<Func<TAggregateRoot, bool>> wherePredicate, Expression<Func<TAggregateRoot, dynamic>> fetchPredicate);

    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TAggregateRoot"></typeparam>
    public interface IRepository<TAggregateRoot> : IRepository<Guid, TAggregateRoot>
        where TAggregateRoot : class, IAggregateRoot
    {

    }
}
